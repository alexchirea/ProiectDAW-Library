using System;
using System.Linq;
using ProiectaDAW_Library.Data;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectDawData context) : base(context) { }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _table.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

        public User GetById(Guid userId)
        {
            return _table.FirstOrDefault(x => x.Id.Equals(userId));
        }
    }
}
