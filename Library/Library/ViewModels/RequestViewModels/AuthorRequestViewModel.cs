using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.RequestViewModels
{
    public class AuthorRequestViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "BirthDate cannot be empty")]
        public DateTime BirthDate { get; set; }

        public int? CountryId { get; set; }

        public CountryRequestViewModel Country { get; set; }

        public List<BookAuthorRequestViewModel> BookAuthors { get; set; }
    }
}
