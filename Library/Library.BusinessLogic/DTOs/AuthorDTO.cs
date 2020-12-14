using System;
using System.Collections.Generic;

namespace Library.BusinessLogic.DTOs
{
    public class AuthorDTO : BaseDTO
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public int? CountryId { get; set; }

        public CountryDTO Country { get; set; }

        public List<BookAuthorDTO> BookAuthors { get; set; }
    }
}
