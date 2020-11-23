using System.Threading.Tasks;
using AutoMapper;
using Library.BusinessLogic.DTOs;
using Library.BusinessLogic.Interfaces;
using Library.ViewModels.RequestViewModels;
using Library.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.ApiControllers
{
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
            return Ok(_mapper.Map<BookResponseViewModel>(books));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<BookResponseViewModel>(await _bookService.GetById(id)));
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                return Ok(await _bookService.Create(_mapper.Map<BookDTO>(book)));
            }
            catch
            {
                return BadRequest("Error occured");
            }
        }

        // PUT api/<BookController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                await _bookService.Update(_mapper.Map<BookDTO>(book));
            }
            catch
            {
                return BadRequest("Error occured");
            }

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
