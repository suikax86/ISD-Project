﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ISD_Project.Server.Models.DTOs
{
    public class UserRegisterRequest
    {
        public UserRegisterRequest() 
        {
            Email = string.Empty;
            Password = string.Empty; 
            ConfirmPassword = string.Empty;
        }
        public UserRegisterRequest(string email, string password, string confirmPassword) 
        {
            Email = email;
            Password = password; 
            ConfirmPassword = confirmPassword;
        } 
        //Validates that the email is in the correct format
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        //Makes sure that the password and confirm password are the same
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }


}