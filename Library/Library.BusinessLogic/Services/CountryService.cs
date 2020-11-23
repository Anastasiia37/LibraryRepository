using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.BusinessLogic.DTOs;
using Library.BusinessLogic.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private readonly ILogger<CountryService> _logger;
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ILogger<CountryService> logger, IRepository<Country> countryRepository, IMapper mapper)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDTO>> GetAll()
        {
            return _mapper.Map<List<CountryDTO>>(await _countryRepository.List());
        }
    }
}
