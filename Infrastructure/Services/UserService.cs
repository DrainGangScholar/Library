using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Services;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return UserDTO.FromUser(user);
        }

        public async Task<UserDTO?> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return UserDTO.FromUser(user);
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
            {
                return UserDTO.EmptyList();
            }
            return users.Select(u => UserDTO.FromUser(u)).ToList();
        }
    }
}
