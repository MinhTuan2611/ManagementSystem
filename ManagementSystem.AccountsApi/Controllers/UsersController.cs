using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using ManagementSystem.Common.Helpers;
using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Users;

namespace ManagementSystem.AccountsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _UsersService;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public UsersController(AccountsDbContext context)
        {
            _UsersService = new UsersService(context);
        }
        #endregion
        // GET api/user/get
        [HttpGet("get")]
        public IActionResult Get(string? searchValue)
        {
            var users = _UsersService.GetAllUsers(searchValue);
            if (users != null)
            {
                var UsersEntities = users as List<UserInfo> ?? users.ToList();
                if (UsersEntities.Any())
                    return Ok(UsersEntities);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        [HttpGet("get-by-username/{username}")]
        public IActionResult GetLogin(string? username)
        {
            var users = _UsersService.GetUserByUsername(username);
            if (users != null)
            {
                return Ok(users);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        [HttpPost("get-login")]
        public IActionResult GetLogin(Login user)
        {
            var users = _UsersService.GetUserLogin(user);
            if (users != null)
            {
                return Ok(users);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }


        // GET api/user/Register
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserRegister user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            int userId = _UsersService.CreateUser(user);
            return Ok(userId);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateUserModel user)
        {
            bool updated = _UsersService.UpdateUser(user.UserId, user.UserEntity);
            return Ok(updated);
        }
        [HttpGet("get-user-roles")]
        public IActionResult GetUserRoles(int userId)
        {
            string roleIds = _UsersService.GetUserRoles(userId);
            return Ok(roleIds);
        }

        [HttpGet("get-user-roles-detail")]
        public IActionResult GetUserRolesDetail(int userId)
        {
            var userRoles = _UsersService.GetUserRoleDetail(userId);
            return Ok(userRoles);
        }

        [HttpPost("change_password")]
        public async Task<ResponseDto> ChangePassword([FromBody]UserChangePasswordRequestDto requestDto)
        {
            return await _UsersService.ChangePassword(requestDto);
        }
    }
}
