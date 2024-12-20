using api.Core.DTOs;

namespace api.Core.Services
{
    public interface IBookService
    {
        public Task<List<BookDTO>> GetAllBooks(bool? isBorrowed);
        public Task<BookDTO> AddBook(CreateBookDTO request);
        Task<BookDTO> UpdateBookAsync(UpdateBookDTO request);
    }
}
