using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models.Base;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Models
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public int noCopies { get; set; }
        public virtual Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public virtual List<Activity> Activities { get; set; } = new List<Activity>();

        public Book() { }

        public Book(BookRequestDTO bookRequestDTO)
        {
            Title = bookRequestDTO.Title;
            noCopies = bookRequestDTO.noCopies;
            AuthorId = bookRequestDTO.AuthorId;
        }
    }
}
