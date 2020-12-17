using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Services;

namespace ProiectaDAW_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authentificate(UserLoginRequestDTO user)
        {
            var result = _userService.Authenticate(user);

            if (result == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterRequestDTO user)
        {
            _userService.Create(user);
            return Ok();
        }
    }
}
