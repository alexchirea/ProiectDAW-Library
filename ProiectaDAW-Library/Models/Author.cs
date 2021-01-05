using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models.Base;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Models
{
    public class Author: BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; } = new List<Book>();

        public Author() { }

        public Author(AuthorRequestDTO authorRequest)
        {
            Name = authorRequest.Name;
        }
    }
}
