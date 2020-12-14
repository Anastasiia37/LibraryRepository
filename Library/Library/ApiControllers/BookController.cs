using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.BusinessLogic.DTOs;
using Library.BusinessLogic.Interfaces;
using Library.Helpers;
using Library.ViewModels.RequestViewModels;
using Library.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.ApiControllers
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAll();
            return Ok(_mapper.Map<List<BookResponseViewModel>>(books));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = _mapper.Map<BookResponseViewModel>(await _bookService.GetById(id));

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] BookSearchRequestViewModel bookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            if (bookRequest.Title == null && bookRequest.ReleaseDate == null)
            {
                return BadRequest();
            }

            var book = _mapper.Map<List<BookResponseViewModel>>
                (await _bookService.SearchWithCondition(bookRequest.Title, bookRequest.ReleaseDate));

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            return Ok(await _bookService.Create(_mapper.Map<BookDTO>(book)));
        }

        // PUT api/<BookController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            await _bookService.Update(_mapper.Map<BookDTO>(book));

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.Delete(id);
            return Ok(id);
        }
    }
}
