using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ResponseViewModels
{
    public class AuthorResponseViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public CountryResponseViewModel Country { get; set; }

        public List<BookAuthorResponseViewModel> BookAuthors { get; set; }
    }
}
