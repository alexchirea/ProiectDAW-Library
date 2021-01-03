using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Services
{
    public interface IAuthorService
    {
        void Create(AuthorRequestDTO authorRequestDTO);
        List<Author> GetByName(string name);
        List<Author> GetAll();
        Author GetById(Guid id);
        void Delete(Guid id);
        void Update(Guid id, AuthorRequestDTO authorRequestDTO);
    }
}
