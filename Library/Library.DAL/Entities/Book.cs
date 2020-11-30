using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Book : EntityBase
    {
        [StringLength(1000)]
        [Required]
        public string Title { get; set; }

        public Publisher Publisher { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? CopiesNumber { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

        public Book()
        {
            BookAuthors = new List<BookAuthor>();
        }
    }
}
