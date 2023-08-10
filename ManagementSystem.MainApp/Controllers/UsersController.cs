using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<UserInfo> users = await HttpRequestsHelper.Get<List<UserInfo>>(Environment.AccountApiUrl + "users/get");
            if (users != null || users.Count > 0)
            {
                return Ok(users);
            }
            return Ok("Users not found");
        }
        [AllowAnonymous]
        [HttpGet("get-by-username/{username}")]
        public async Task<IActionResult> User(string username)
        {
            UserInfo userInfo = await HttpRequestsHelper.Get<UserInfo>(Environment.AccountApiUrl + "users/get-by-username/" + username);
            if (userInfo != null)
            {
                return Ok(userInfo);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        // GET api/user/Register
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegister user)
        {
            int userId = await HttpRequestsHelper.Post<int>(Environment.AccountApiUrl + "users/register", user);
            if (userId > 0) 
            {
                return Ok(userId);
            } else if (userId == -2) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Username already exists");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
    }
}
