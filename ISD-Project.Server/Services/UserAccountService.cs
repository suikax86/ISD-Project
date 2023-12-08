﻿using AutoMapper;
using ISD_Project.Server.DataAccess;
using ISD_Project.Server.Models;
using ISD_Project.Server.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ISD_Project.Server.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICryptoService _cryptoService;
        private readonly IMapper _mapper;
        public UserAccountService(ApplicationDbContext dbContext, ICryptoService cryptoService, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._cryptoService = cryptoService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Register(UserAccountRegisterRequest request)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Validate request
                    if (request is null)
                    {
                        return new BadRequestObjectResult("Request is null");
                    }

                    if (await _dbContext.UserAccounts.AnyAsync(u => u.Email == request.Email))
                    {
                        return new BadRequestObjectResult("User already exists");
                    }

                    var (passwordHash, passwordSalt) = await _cryptoService.CreatePasswordHash(request.Password);

                    var userAccount = new UserAccount
                    {
                        Email = request.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                    };
                    // If not customer then activate userAccount by default
                    userAccount.IsActivated = request.Role == RoleType.Customer ? (int)AccountStatus.Inactive : (int)AccountStatus.Active;
                    var token = await _cryptoService.CreateToken(userAccount);
                    if (token != null)
                    {
                        userAccount.VerificationToken = token;
                    }
                    else
                    {
                        return new BadRequestObjectResult("Token is null");
                    }
                    var userAccountResult = await _dbContext.UserAccounts.AddAsync(userAccount);
                    await _dbContext.SaveChangesAsync();


                    int userId = 0;
                    if (request.Role != RoleType.Customer)
                    {
                        var role = request.Role;
                        switch (role)
                        {

                            case RoleType.Admin:
                                var admin = new Admin(request.Email, userAccountResult.Entity.Id, userAccountResult.Entity);
                                var v1 = await _dbContext.Admins.AddAsync(admin);
                                await _dbContext.SaveChangesAsync();
                                userId = v1.Entity.Id;
                                break;
                            case RoleType.FinancialDepartment:
                                var financialDepartment = new FinancialDepartment(request.Email, userAccountResult.Entity.Id, userAccountResult.Entity);
                                var v2 = await _dbContext.FinancialDepartments.AddAsync(financialDepartment);
                                await _dbContext.SaveChangesAsync();
                                userId = v2.Entity.Id;
                                break;
                            case RoleType.ValidationDepartment:
                                var validationDepartment = new ValidationDepartment(request.Email, userAccountResult.Entity.Id, userAccountResult.Entity);
                                var v3 = await _dbContext.ValidationDepartments.AddAsync(validationDepartment);
                                await _dbContext.SaveChangesAsync();
                                userId = v3.Entity.Id;
                                break;
                            case RoleType.CustomerCareDepartment:
                                var customerCareDepartment = new CustomerCareDepartment(request.Email, userAccountResult.Entity.Id, userAccountResult.Entity);
                                var v4 = await _dbContext.CustomerCareDepartments.AddAsync(customerCareDepartment);
                                await _dbContext.SaveChangesAsync();
                                userId = v4.Entity.Id;
                                break;
                            default:
                                throw new Exception("Role is not valid");
                        }
                        //Update UserId for UserAccount
                        userAccountResult.Entity.UserId = userId;
                        _dbContext.UserAccounts.Update(userAccountResult.Entity);
                        await _dbContext.SaveChangesAsync();
                    }

                    var userRole = new UserRole
                    {
                        UserId = userAccount.Id,
                        RoleId = (int)request.Role
                    };

                    await _dbContext.UserRoles.AddAsync(userRole);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync(); // Commit transaction if all commands succeed
                    var response = new { userAccountId = userAccountResult.Entity.Id, RoleType = request.Role.ToString(), message = "UserAccount successfully created" };
                    return new OkObjectResult(response);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction if exception occurs
                    return new ObjectResult(ex.Message)
                    {
                        StatusCode = 500 // Internal Server Error
                    };
                }
            }
        }
        public async Task<IActionResult> Login(UserAccountLoginRequest request)
        {
            var user = await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return new BadRequestObjectResult("User does not exist");
            }

            if (!await _cryptoService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new BadRequestObjectResult("Password is incorrect");
            }

            if (user.VerificationToken != null)
            {
                await Verify(user.VerificationToken);
            }

            if (user.VerifiedAt == null)
            {
                return new BadRequestObjectResult("User does not verified");
            }

            var userDto = new UserAccountLoginResponse
            {
                UserAccountId = user.Id,
                Token = user.VerificationToken,
                Role = await GetUserRole(user.Id),
                UserId = user.UserId ?? 0,
                IsActivated = user.IsActivated
            };


            return new OkObjectResult(userDto);
        }
        public async Task<IActionResult> Verify(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return new BadRequestObjectResult("Token is null or empty");
            }

            var user = await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user == null)
            {
                return new BadRequestObjectResult("Invalid token");
            }

            user.VerifiedAt = System.DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult("User Verified");
        }

        public async Task<IActionResult> GetUserAccount()
        {
            try
            {
                var userAccounts = await _dbContext.UserAccounts.ToListAsync();
                if (userAccounts is null || userAccounts.Count == 0)
                {
                    return new BadRequestObjectResult("User Accounts does not exist");
                }
                var userAccountsDto = _mapper.Map<List<UserAccountDto>>(userAccounts);
                return new OkObjectResult(userAccountsDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500 // Internal Server Error
                };
            }
        }

        public async Task<IActionResult> GetUserAccount(int id)
        {
            try
            {
                var userAccount = await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.Id == id);
                if (userAccount is null)
                {
                    return new BadRequestObjectResult("User Account does not exist");
                }
                var userAccountDto = _mapper.Map<UserAccountDto>(userAccount);
                return new OkObjectResult(userAccountDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<List<String>> GetUserRole(int userAccountId)
        {
            var userRoles = await _dbContext.UserRoles
                .Where(ur => ur.UserId == userAccountId)
                .Select(ur => ur.Role.Name).ToListAsync();
            if (userRoles == null || userRoles.Count == 0)
            {
                return new List<string>();
            }
            return userRoles;
        }
        public async Task<IActionResult> ForgotPassword(UserForgotPasswordRequest request)
        {
            try
            {
                var user = await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (user == null)
                {
                    return new BadRequestObjectResult("User does not exist");
                }
                user.PasswordResetToken = await _cryptoService.CreateRandomToken();
                user.RestTokenExpires = System.DateTime.UtcNow.AddHours(1);
                await _dbContext.SaveChangesAsync();
                return new OkObjectResult("You may now reset your password");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500 // Internal Server Error
                };
            }

        }
        public async Task<IActionResult> ResetPassword(UserResetPasswordRequest request)
        {
            try
            {
                var user = await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
                if (user == null)
                {
                    return new BadRequestObjectResult("Invalid token");
                }
                if (user.RestTokenExpires < System.DateTime.UtcNow)
                {
                    return new BadRequestObjectResult("Token has expired");
                }
                var (passwordHash, passwordSalt) = await _cryptoService.CreatePasswordHash(request.Password);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PasswordResetToken = null;
                user.RestTokenExpires = null;

                await _dbContext.SaveChangesAsync();
                return new OkObjectResult("Password successfully reset");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500 // Internal Server Error
                };
            }

        }
    }
}
