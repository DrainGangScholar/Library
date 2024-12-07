using api.Core.DTOs;
using api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks([FromQuery] bool? isBorrowed)
        {
            return Ok(await bookService.GetAllBooks(isBorrowed));
        }
        [HttpPost]
        public async Task<ActionResult<BookDTO>> AddBook([FromBody] CreateBookDTO request)
        {
            return Ok(await bookService.AddBook(request));
        }
    }
}
