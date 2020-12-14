using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.RequestViewModels
{
    public class AuthorRequestViewModel
    {
        public int Id { get; set; }

        //[MaxLength(255)]
        [Display(Name = "Last Name")]
        //[DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0}'s length should be between {2} and {1}.")]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "BirthDate cannot be empty")]
        public DateTime BirthDate { get; set; }

        public int? CountryId { get; set; }

        public CountryRequestViewModel Country { get; set; }

        public List<BookAuthorRequestViewModel> BookAuthors { get; set; }
    }
}
