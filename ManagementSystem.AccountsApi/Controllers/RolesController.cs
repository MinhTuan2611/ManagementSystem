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

namespace ManagementSystem.AccountsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public RolesController(AccountsDbContext context)
        {
            _rolesService = new RolesService(context);
        }
        #endregion
        [HttpGet("get")]
        public IActionResult Get()
        {
            var roles = _rolesService.GetAllRoles();
            if (roles != null) 
            {  
                return Ok(roles);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        [HttpPost("create")]
        public IActionResult Create(string roleName)
        {
            int roleId = _rolesService.CreateRole(roleName);
            return Ok(roleId);
        }

        [HttpPost("update")]
        public IActionResult Update(RoleModels role)
        {
            bool updated = _rolesService.UpdateRole(role);
            return Ok(updated);
        }
    }
}
