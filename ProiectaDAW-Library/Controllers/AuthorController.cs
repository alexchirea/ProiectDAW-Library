using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Services;

namespace ProiectaDAW_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorController: ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Create(AuthorRequestDTO authorRequestDTO)
        {
            _authorService.Create(authorRequestDTO);
            return Ok();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_authorService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll(string name)
        {
            List<AuthorResponseDTO> authors = _authorService.GetAll().Select(x => new AuthorResponseDTO(x)).ToList();
            return Ok(authors);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            List<AuthorResponseDTO> authors = _authorService.GetByName(name).Select(x => new AuthorResponseDTO(x)).ToList();
            return Ok(authors);
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(Guid id, AuthorRequestDTO authorRequestDTO)
        {
            _authorService.Update(id, authorRequestDTO);
            return Ok();
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(Guid id)
        {
            _authorService.Delete(id);
            return Ok();
        }

    }
}
