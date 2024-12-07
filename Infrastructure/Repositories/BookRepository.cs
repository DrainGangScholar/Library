using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks(bool? isBorrowed)
        {
            var booksQuery = _context.Books.AsQueryable();
            if (isBorrowed != null)
            {
                if (isBorrowed.Value)
                {
                    booksQuery = booksQuery.Where(r => r.LoanId != null);
                }
                else
                {
                    booksQuery = booksQuery.Where(r => r.LoanId == null);
                }
            }
            return await booksQuery.ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            var createdBook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return createdBook.Entity;
        }


        public async Task<Book?> GetByIdAsync(Guid bookId)
        {
            return await _context.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
