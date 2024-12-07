using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services;

namespace api.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookDTO>> GetAllBooks(bool? isBorrowed)
        {
            var books = await _repository.GetAllBooks(isBorrowed);
            return (books.Select(b => BookDTO.From(b)).ToList());
        }

        public async Task<BookDTO> AddBook(CreateBookDTO request)
        {
            var book = new Book
            {
                ISBN = request.ISBN,
                Name = request.Name,
                Description = request.Description
            };
            var createdBook = await _repository.AddBook(book);
            return BookDTO.From(createdBook);
        }
    }
}
