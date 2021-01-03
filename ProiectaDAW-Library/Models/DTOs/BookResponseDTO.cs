using System;
namespace ProiectaDAW_Library.Models.DTOs
{
    public class BookResponseDTO
    {
        public string Title;
        public string Author;

        public BookResponseDTO() { }

        public BookResponseDTO(Book book)
        {
            Title = book.Title;
            Author = book.Author.Name;
        }
    }
}
