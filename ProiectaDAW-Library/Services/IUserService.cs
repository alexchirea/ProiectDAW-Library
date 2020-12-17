using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Services
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserLoginRequestDTO model);
        void Create(UserRegisterRequestDTO model);
        User GetById(Guid userId);
    }
}
