using System;
using System.Collections.Generic;

namespace Library.BusinessLogic.DTOs
{
    public class BookDTO : BaseDTO
    {
        public string Title { get; set; }

        public int PublisherId { get; set; }

        public PublisherDTO Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? CopiesNumber { get; set; }

        public List<BookAuthorDTO> BookAuthors { get; set; }
    }
}
