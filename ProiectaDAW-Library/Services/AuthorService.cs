using System;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Helpers;
using ProiectaDAW_Library.Repositories;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ProiectaDAW_Library.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly AppSettings _appSettings;
        public IAuthorRepository _authorRepository;

        public AuthorService(IOptions<AppSettings> appSettings, IAuthorRepository authorRepository)
        {
            _appSettings = appSettings.Value;
            _authorRepository = authorRepository;
        }

        public void Create(AuthorRequestDTO authorRequestDTO)
        {
            _authorRepository.Create(new Author(authorRequestDTO));
            _authorRepository.Save();
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll().Result;
        }

        public List<Author> GetByName(string name)
        {
            return _authorRepository.GetByName(name);
        }

        public Author GetById(Guid id)
        {
            return _authorRepository.FindById(id);
        }

        public void Update(Guid id, AuthorRequestDTO authorRequestDTO)
        {
            Author a = _authorRepository.FindById(id);
            a.Name = authorRequestDTO.Name;
            _authorRepository.Update(a);
            _authorRepository.Save();
        }

        public void Delete(Guid id)
        {
            Author a = _authorRepository.FindById(id);
            _authorRepository.Delete(a);
            _authorRepository.Save();
        }
    }
}
