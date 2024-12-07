using api.Core.DTOs;
using api.Core.Services;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] CreateUserDTO request)
        {
            var user = await _userService.AddUser(request);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser([FromRoute] Guid id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}