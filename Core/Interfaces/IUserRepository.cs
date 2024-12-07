using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> FindAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid userId);
    }
}
