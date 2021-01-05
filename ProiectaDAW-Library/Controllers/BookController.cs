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
            return Ok(_bookService.GetAll());
        }

        [HttpGet("title/{title}")]
        public IActionResult GetByName(string title)
        {
            return Ok(_bookService.GetByTitle(title));
        }

        [HttpGet("author/{author}")]
        public IActionResult GetByTitle(string author)
        {
            return Ok(_bookService.GetByAuthor(author));
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
