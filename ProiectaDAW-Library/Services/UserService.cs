using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using ProiectaDAW_Library.Models.DTOs;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Helpers;
using ProiectaDAW_Library.Repositories;

namespace ProiectaDAW_Library.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public IUserRepository _userRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public User GetById(Guid userId)
        {
            return _userRepository.GetById(userId);
        }

        public UserResponseDTO Authenticate(UserLoginRequestDTO model)
        {
            User user = _userRepository.GetByUsernameAndPassword(model.Username, model.Password);

            if (user == null) return null;

            var token = GenerateUserJWTToken(user);

            return new UserResponseDTO(user, token);
        }

        public void Create(UserRegisterRequestDTO model)
        {
            _userRepository.Create(new User(model));
            _userRepository.Save();
        }

        private string GenerateUserJWTToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
