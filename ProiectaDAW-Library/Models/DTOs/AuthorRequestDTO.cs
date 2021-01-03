using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectaDAW_Library.Models.DTOs
{
    public class AuthorRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
