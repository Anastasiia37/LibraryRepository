using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BusinessLogic.DTOs;

namespace Library.BusinessLogic.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDTO>> GetAll();
    }
}
