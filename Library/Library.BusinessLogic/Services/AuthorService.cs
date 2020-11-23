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
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger;
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(ILogger<AuthorService> logger, IRepository<Author> authorRepository, IMapper mapper)
        {
            _logger = logger;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(AuthorDTO author)
        {
            int id = await _authorRepository.Insert(_mapper.Map<Author>(author));
            return id;
        }

        public async Task Update(AuthorDTO author)
        {
            await _authorRepository.Update(_mapper.Map<Author>(author));
        }

        public async Task<List<AuthorDTO>> GetAll()
        {
            return _mapper.Map<List<AuthorDTO>>(await _authorRepository.List());
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            return _mapper.Map<AuthorDTO>(await _authorRepository.GetById(id));
        }

        public async Task Delete(int id)
        {
            var author = await _authorRepository.GetById(id);
            await _authorRepository.Delete(author);
        }
    }
}
