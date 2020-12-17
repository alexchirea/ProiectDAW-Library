using System;
namespace ProiectaDAW_Library.Models
{
    public class Activity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public string Action { get; set; } // BORROW or RETURN
    }
}
