using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.RequestViewModels
{
    public class BookRequestViewModel
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int? CopiesNumber { get; set; }

        public List<BookAuthorRequestViewModel> BookAuthors { get; set; }
    }
}
