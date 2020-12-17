using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public interface IAuthorRepository: IGenericRepository<Author>
    {
        List<Author> GetByName(string name);
    }
}
