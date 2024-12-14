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

        public async Task<BookDTO> UpdateBookAsync(UpdateBookDTO request)
        {
            var book = await _repository.GetByIdAsync(request.id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with {request.id} not found!");
            }
            if (request.Name != string.Empty)
            {
                book.Name = request.Name;
            }
            if (request.Description != string.Empty)
            {
                book.Description = request.Description;
            }
            if (request.ISBN != string.Empty)
            {
                book.ISBN = request.ISBN;
            }
            var updatedBook = await _repository.UpdateAsync(book);
            return BookDTO.From(updatedBook);
        }
    }
}
