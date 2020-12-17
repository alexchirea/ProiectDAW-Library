using System;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetById(Guid userId);
    }
}
