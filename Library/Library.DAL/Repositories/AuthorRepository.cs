using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(LibraryContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Author> GetById(int id)
        {
            return await _dbContext.Set<Author>().Include(author => author.Country).FirstOrDefaultAsync(author => author.Id == id);
        }

        public override async Task<List<Author>> List()
        {
            return await _dbContext.Set<Author>().Include(author => author.Country).ToListAsync();
        }
    }
}
