namespace Library.BusinessLogic.DTOs
{
    public class BookAuthorDTO
    {
        public int BookId { get; set; }

        public BookDTO Book { get; set; }

        public int AuthorId { get; set; }

        public AuthorDTO Author { get; set; }
    }
}
