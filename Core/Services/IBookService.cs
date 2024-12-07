using api.DTOs;

namespace api.Services
{
    public interface IBookService
    {
        public Task<List<BookDTO>> GetAllBooks();
        public Task<BookDTO> AddBook(CreateBookDTO request);
    }
}
