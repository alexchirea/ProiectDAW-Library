using System;
using System.Collections.Generic;
using System.Linq;
using ProiectaDAW_Library.Data;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ProiectDawData context) : base(context) { }

        public List<Book> GetByAuthor(string author)
        {
            return _table.Where(x => x.Author.Name.ToLower().Contains(author.ToLower())).ToList();
        }

        public List<Book> GetByTitle(string title)
        {
            return _table.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}
