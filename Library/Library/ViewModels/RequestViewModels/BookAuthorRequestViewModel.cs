﻿namespace Library.ViewModels.RequestViewModels
{
    public class BookAuthorRequestViewModel
    {
        public int BookId { get; set; }

        public BookRequestViewModel Book { get; set; }

        public int AuthorId { get; set; }

        public AuthorRequestViewModel Author { get; set; }
    }
}
