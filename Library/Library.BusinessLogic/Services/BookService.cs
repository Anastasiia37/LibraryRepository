using System;
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
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(ILogger<BookService> logger, IRepository<Book> bookRepository, IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(BookDTO book)
        {
            int id = await _bookRepository.Insert(_mapper.Map<Book>(book));
            return id;
        }

        public async Task Update(BookDTO book)
        {
            await _bookRepository.Update(_mapper.Map<Book>(book));
        }

        public async Task<List<BookDTO>> GetAll()
        {
            return _mapper.Map<List<BookDTO>>(await _bookRepository.List());
        }

        public async Task<List<BookDTO>> SearchByTitle(string title)
        {
            return _mapper.Map<List<BookDTO>>(await _bookRepository.List(book => book.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase)));
        }

        public async Task<BookDTO> GetById(int id)
        {
            return _mapper.Map<BookDTO>(await _bookRepository.GetById(id));
        }
    }
}
