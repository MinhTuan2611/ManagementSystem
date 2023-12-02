using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos.Users;
using ManagementSystem.MainApp.Services.IServices;
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
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string? searchValue)
        {
            List<UserInfo> users = await HttpRequestsHelper.Get<List<UserInfo>>(Environment.AccountApiUrl + "users/get?searchValue=" + searchValue);
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

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateUserModel user)
        {
            bool userId = await HttpRequestsHelper.Post<bool>(Environment.AccountApiUrl + "users/update", user);
            return Ok(userId);
        }

        [HttpPost("change_password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordRequestDto requestDto)
        {

            var result = await _service.ChangePassword(requestDto);

            if (result.IsSuccess)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}
