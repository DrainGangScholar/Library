using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Services;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            if (books == null)
            {
                return BookDTO.EmptyList();
            }
            return (books.Select(b => BookDTO.From(b)).ToList());
        }

        public async Task<BookDTO> AddBook(CreateBookDTO request)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                ISBN = request.ISBN,
                Name = request.Name,
                Description = request.Description
            };
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return BookDTO.From(book);
        }
    }
}
