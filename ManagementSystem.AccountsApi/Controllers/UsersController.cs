using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data.Entities;
using ManagementSystem.EmployeesApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        // GET api/product
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
            return StatusCode(404, "Products not found");
        }
    }
}
