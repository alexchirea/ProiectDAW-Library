using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Services;

namespace ProiectaDAW_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Create(BookRequestDTO bookRequestDTO)
        {
            _bookService.Create(bookRequestDTO);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(string name)
        {
            List<BookResponseDTO> books = _bookService.GetAll().Select(x => new BookResponseDTO(x)).ToList();
            return Ok(books);
        }

        [HttpGet("title/{title}")]
        public IActionResult GetByName(string title)
        {
            List<BookResponseDTO> books = _bookService.GetByTitle(title).Select(x => new BookResponseDTO(x)).ToList();
            return Ok(books);
        }

        [HttpGet("author/{author}")]
        public IActionResult GetByTitle(string author)
        {
            List<BookResponseDTO> books = _bookService.GetByAuthor(author).Select(x => new BookResponseDTO(x)).ToList();
            return Ok(books);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_bookService.findById(id));
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(Guid id, BookRequestDTO bookRequestDTO)
        {
            _bookService.Update(id, bookRequestDTO);
            return Ok();
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(Guid id)
        {
            _bookService.Delete(id);
            return Ok();
        }

    }
}
