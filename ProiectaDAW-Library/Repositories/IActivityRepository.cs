using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public interface IActivityRepository: IGenericRepository<Activity>
    {
        void create(Activity activity);
        List<Activity> GetByUser(Guid userId);
        List<Activity> GetByBook(Guid bookId);
    }
}
