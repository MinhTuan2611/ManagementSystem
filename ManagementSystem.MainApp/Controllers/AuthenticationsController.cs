using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationServices _AuthServices;
        public AuthenticationsController(IConfiguration config)
        {
            _AuthServices = new AuthenticationServices(config);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Post(Login _userData)
        {
            if (_userData != null && _userData.Password != null)
            {
                string token = await _AuthServices.GenerateToken(_userData);

                if (token != null)
                {
                    return Ok(new TokenRes{ Token = token, Status = "Success", Username = _userData.UserName });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
