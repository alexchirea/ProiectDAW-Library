using System;
using System.Collections.Generic;
using System.Linq;
using ProiectaDAW_Library.Data;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public class ActivityRepository: GenericRepository<Activity>, IActivityRepository
    {
        public IBookRepository _bookRepository;

        public ActivityRepository(ProiectDawData context, IBookRepository bookRepository) : base(context) {
            _bookRepository = bookRepository;
        }

        public void create(Activity activity)
        {
            Book book = activity.Book;
            if (activity.Action == "BORROW" && book.noCopies > 1)
            {
                book.noCopies--;
                Create(activity);
                _bookRepository.Update(book);
            }
            if (activity.Action == "RETURN")
            {
                book.noCopies++;
                Create(activity);
                _bookRepository.Update(book);
            }
        }

        public List<Activity> GetByBook(Guid bookId)
        {
            return _table.Where(x => x.BookId.Equals(bookId)).ToList();
        }

        public List<Activity> GetByUser(Guid userId)
        {
            return _table.Where(x => x.UserId.Equals(userId)).ToList();
        }
    }
}
