using System;
using System.Collections.Generic;
using System.Linq;

namespace ProiectaDAW_Library.Models.DTOs
{
    public class AuthorResponseDTO
    {

        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Guid Id { get; set; }

        public AuthorResponseDTO() { }

        public AuthorResponseDTO(Author a)
        {
            Name = a.Name;
            Id = a.Id;
            if (a.Books != null) Books = a.Books.ToList();
        }

    }
}
