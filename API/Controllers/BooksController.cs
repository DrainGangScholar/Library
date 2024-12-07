using api.Core.DTOs;
using api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpPost]
        public async Task<ActionResult<BookDTO>> AddBook([FromBody] CreateBookDTO request)
        {
            return Ok(await _bookService.AddBook(request));
        }
    }
}
