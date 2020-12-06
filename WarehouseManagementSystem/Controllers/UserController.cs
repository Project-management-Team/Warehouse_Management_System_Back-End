using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Api.Controllers.Models;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<Users> Login([FromQuery] string login, [FromQuery] string password)
        {
            var validUser = await _userService.ValidateUser(new Users
            {
                Login = login,
                Password = password
            });

            return validUser;
        }

        [HttpPost("register")]
        public async Task<Users> Register([FromBody] UserModel model)
        {
            var user = new Users
            {
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                IsAdmin = model.IsAdmin
            };

            await _userService.CreateUser(user);

            return user;
        }

        [HttpGet("all")]
        public async Task<Users[]> GetAll()
        {
            return await _userService.GetAllUsers();
        }

        [HttpDelete]
        public async Task DeleteUser([FromQuery] int userId)
        {
            await _userService.DeleteUser(userId);
        }
    }
}
