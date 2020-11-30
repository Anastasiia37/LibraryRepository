using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Book> GetById(int id)
        {
            return await _dbContext.Books
                .Include(book => book.BookAuthors)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public override async Task<List<Book>> List()
        {
            return await _dbContext.Books
                .Include(book => book.BookAuthors)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .ToListAsync();
        }
    }
}
