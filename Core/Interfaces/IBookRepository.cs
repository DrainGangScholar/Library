using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);
        Task<List<Book>> GetAllBooks(bool? isBorrowed);
        Task<Book?> GetByIdAsync(Guid bookId);
        void Update(Book book);
        Task<Book> UpdateAsync(Book? book);
    }
}
