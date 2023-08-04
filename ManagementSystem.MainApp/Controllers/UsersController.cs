using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        // GET api/user/Register
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserRegister user)
        {
      
            return StatusCode(StatusCodes.Status500InternalServerError, "Invalid create user");
        }
    }
}
