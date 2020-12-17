using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models.Base;

namespace ProiectaDAW_Library.Models
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public int noCopies { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
