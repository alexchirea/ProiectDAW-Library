using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectaDAW_Library.Models.DTOs
{
    public class UserRegisterRequestDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
