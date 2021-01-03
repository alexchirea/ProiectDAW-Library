using System;
using System.Collections.Generic;
using System.Linq;
using ProiectaDAW_Library.Data;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ProiectDawData context) : base(context) { }

        public List<Author> GetByName(string name)
        {
            return _table.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
