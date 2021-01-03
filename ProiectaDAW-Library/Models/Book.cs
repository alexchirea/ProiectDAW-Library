﻿using System;
using System.Collections.Generic;
using ProiectaDAW_Library.Models.Base;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Models
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public int noCopies { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Activity> Activities { get; set; }

        public Book() { }

        public Book(BookRequestDTO bookRequestDTO)
        {
            Title = bookRequestDTO.Title;
            noCopies = bookRequestDTO.noCopies;
            AuthorId = bookRequestDTO.AuthorId;
        }
    }
}
