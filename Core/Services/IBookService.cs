using api.Core.DTOs;

namespace api.Core.Services
{
    public interface IBookService
    {
        public Task<List<BookDTO>> GetAllBooks();
        public Task<BookDTO> AddBook(CreateBookDTO request);
    }
}
