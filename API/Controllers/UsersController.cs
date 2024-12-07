using api.Core.DTOs;
using api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] CreateUserDTO request)
        {
            var user = await userService.AddUser(request);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser([FromRoute] Guid id)
        {
            var user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }
    }
}
