using Microsoft.AspNetCore.Mvc;
using api.Entities;
using api.Data;
using api.Services;
using api.DTOs;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, DataContext context)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody] CreateBookDTO request)
        {
            return Ok(await _bookService.AddBook(request));
        }
    }
}
