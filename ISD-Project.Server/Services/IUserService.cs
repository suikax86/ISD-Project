﻿using ISD_Project.Server.Models;
using ISD_Project.Server.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISD_Project.Server.Services
{
    public interface IUserService
    {
        Task<IActionResult> GetUser();
        Task<IActionResult> GetUserById(int id);
        Task<IActionResult> GetUserByRole(RoleType role);
        
    }
}
