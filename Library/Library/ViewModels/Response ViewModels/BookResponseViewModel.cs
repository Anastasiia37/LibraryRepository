using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ResponseViewModels
{
    public class BookResponseViewModel
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Title { get; set; }

        public PublisherResponseViewModel Publisher { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? CopiesNumber { get; set; }

        public List<BookAuthorResponseViewModel> BookAuthors { get; set; }
    }
}
