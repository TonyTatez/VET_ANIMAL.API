﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoBaseNetCore.DTOs.SecurityDTOs
{
    public class UserLoginInfo
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegisterInfo
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}