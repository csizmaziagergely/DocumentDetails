﻿using System.ComponentModel.DataAnnotations;

namespace DocumentDetails.DTOs
{
    public class UserCreateLogin
    {
        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters long")]
        public string UserName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long")]
        public string Password { get; set; }
    }
}
