using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models.Base;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Models
{
    public class Author: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

        public Author() { }

        public Author(AuthorRequestDTO authorRequest)
        {
            Name = authorRequest.Name;
        }
    }
}
