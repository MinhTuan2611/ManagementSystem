using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data.Entities;
using ManagementSystem.EmployeesApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using ManagementSystem.Common.Helpers;
using ManagementSystem.AccountsApi.Models;

namespace ManagementSystem.AccountsApi.Controllers
{
    [Authorize]
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
        [HttpGet(Name = "Get")]
        public IActionResult Get()
        {
            var users = _UsersService.GetAllUsers();
            if (users != null)
            {
                var UsersEntities = users as List<User> ?? users.ToList();
                if (UsersEntities.Any())
                    return Ok(UsersEntities);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        // GET api/user/Register
        [AllowAnonymous]
        [HttpPost(Name = "Register")]
        public IActionResult Register(UserRegister user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            int userId = _UsersService.CreateUser(user);
            if (userId != null)
            {
                return Ok(userId);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Invalid create user");
        }
    }
}
