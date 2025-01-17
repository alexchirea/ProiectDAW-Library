﻿using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        List<Book> GetByTitle(string title);
        List<Book> GetByAuthor(string author);
    }
}
