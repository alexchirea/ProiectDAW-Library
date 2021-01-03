using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Services
{
    public interface IBookService
    {
        void Create(BookRequestDTO bookRequest);
        List<Book> GetByTitle(string title);
        List<Book> GetByAuthor(string author);
        List<Book> GetAll();
        void Delete(Guid id);
        void Update(Guid id, BookRequestDTO bookRequest);
        Book findById(Guid id);
    }
}
