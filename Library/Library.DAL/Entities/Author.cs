using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Author : EntityBase
    {
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }
    }
}
