using System;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Helpers;
using ProiectaDAW_Library.Repositories;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ProiectaDAW_Library.Services
{
    public class BookService : IBookService
    {
        private readonly AppSettings _appSettings;
        public IBookRepository _bookRepository;
        public IAuthorRepository _authorRepository;

        public BookService(IOptions<AppSettings> appSettings, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _appSettings = appSettings.Value;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public void Create(BookRequestDTO bookRequest)
        {
            Author author = _authorRepository.FindById(bookRequest.AuthorId);
            if (author == null) throw new NotSupportedException();
            Book book = new Book(bookRequest);
            book.Author = author;
            _bookRepository.Create(book);
            _bookRepository.Save();
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().Result;
        }

        public List<Book> GetByAuthor(string author)
        {
            return _bookRepository.GetByAuthor(author);
        }

        public List<Book> GetByTitle(string title)
        {
            return _bookRepository.GetByTitle(title);
        }

        public void Delete(Guid id)
        {
            Book b = _bookRepository.FindById(id);
            _bookRepository.Delete(b);
            _bookRepository.Save();
        }

        public void Update(Guid id, BookRequestDTO bookRequest)
        {
            Book b = _bookRepository.FindById(id);
            

            if (bookRequest.AuthorId != null)
            {
                Author author = _authorRepository.FindById(bookRequest.AuthorId);
                if (author == null) throw new NotSupportedException();
                b.Author = author;
            }

            if (bookRequest.Title != null)
            {
                b.Title = bookRequest.Title;
            }

            _bookRepository.Update(b);
            _bookRepository.Save();
        }

        public Book findById(Guid id)
        {
            return _bookRepository.FindById(id);
        }
    }
}
