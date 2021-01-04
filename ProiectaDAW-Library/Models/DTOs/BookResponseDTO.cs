using System;
namespace ProiectaDAW_Library.Models.DTOs
{
    public class BookResponseDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid AuthorId { get; set; }
        public int noCopies { get; set; }

        public BookResponseDTO() { }

        public BookResponseDTO(Book book)
        {
            Title = book.Title;
            Author = book.Author.Name;
            noCopies = book.noCopies;
            AuthorId = book.AuthorId;
        }
    }
}
