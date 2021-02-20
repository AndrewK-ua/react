using System.Threading.Tasks;
using Lab1.Services.Interfaces;
using Lab1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.Api
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            var authorizedUserViewModel = await _userService.RegisterAsync(userRegisterViewModel);

            return Ok(authorizedUserViewModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginViewModel userLoginViewModel)
        {
            var authorizedUserViewModel = await _userService.LoginAsync(userLoginViewModel);

            return Ok(authorizedUserViewModel);
        }
    }
}
