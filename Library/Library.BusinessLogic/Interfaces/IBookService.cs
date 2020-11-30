using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BusinessLogic.DTOs;

namespace Library.BusinessLogic.Interfaces
{
    public interface IBookService
    {
        Task<int> Create(BookDTO item);

        Task Update(BookDTO item);

        Task<List<BookDTO>> GetAll();

        Task<BookDTO> GetById(int id);

        Task<List<BookDTO>> SearchByTitle(string title);
    }
}
