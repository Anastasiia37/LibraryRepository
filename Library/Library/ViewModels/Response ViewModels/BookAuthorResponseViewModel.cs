﻿namespace Library.ViewModels.ResponseViewModels
{
    public class BookAuthorResponseViewModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public BookResponseViewModel Book { get; set; }

        public int AuthorId { get; set; }

        public AuthorResponseViewModel Author { get; set; }
    }
}
