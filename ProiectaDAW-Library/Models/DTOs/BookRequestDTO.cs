using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectaDAW_Library.Models.DTOs
{
    public class BookRequestDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int noCopies { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
