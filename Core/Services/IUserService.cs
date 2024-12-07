using api.Core.DTOs;

namespace api.Core.Services
{
    public interface IUserService
    {
        public Task<UserDTO> AddUser(CreateUserDTO request);
        public Task<UserDTO?> GetUser(Guid id);
        public Task<List<UserDTO>> GetAllUsers();
    }
}
