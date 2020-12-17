using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectaDAW_Library.Models.DTOs
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
