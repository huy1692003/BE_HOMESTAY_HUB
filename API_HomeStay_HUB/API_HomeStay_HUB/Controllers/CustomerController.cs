using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> registerCus([FromBody] RegisterCusDTO reg)
        {
            if (await _userService.addUser(new Model.User { Username = reg.Username, Password = reg.Password, FullName = reg.Fullname, Gender = reg.Gender }, 0))
            {
                return Ok("register success");
            }

            return BadRequest();

        }
        [HttpPost("login")]
        public async Task<IActionResult> login(string Username, string Password)
        {
            var LoginRes = await _userService.loginUser(Username, Password);
            if (LoginRes != null)
            {
                return Ok(LoginRes);
            }

            return NotFound("Login faild");

        }
    }
}
