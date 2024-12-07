using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services;

namespace api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> AddUser(CreateUserDTO request)
        {
            var user = new User
            {
                FirstName = request.FistName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };
            var createdUser = await _repository.AddAsync(user);
            return UserDTO.FromUser(createdUser);
        }

        public async Task<UserDTO?> GetUser(Guid id)
        {
            var user = await _repository.FindAsync(id);
            return UserDTO.FromUser(user);
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => UserDTO.FromUser(u)).ToList();
        }
    }
}
