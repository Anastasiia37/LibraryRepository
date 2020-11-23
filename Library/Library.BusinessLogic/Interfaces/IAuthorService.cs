using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BusinessLogic.DTOs;

namespace Library.BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        Task<int> Create(AuthorDTO item);

        Task Update(AuthorDTO item);

        Task<List<AuthorDTO>> GetAll();

        Task<AuthorDTO> GetById(int id);

        Task Delete(int id);
    }
}
