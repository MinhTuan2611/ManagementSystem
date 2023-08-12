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
    public class RolesController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<RoleModels> roles = await HttpRequestsHelper.Get<List<RoleModels>>(Environment.AccountApiUrl + "roles/get");
            if (roles != null || roles.Count > 0)
            {
                return Ok(roles);
            }
            return Ok("Users not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string roleName)
        {
            int roleId = await HttpRequestsHelper.Post<int>(Environment.AccountApiUrl + "roles/create", roleName);
            if (roleId > 0) 
            {
                return Ok(roleId);
            } else if (roleId == -2) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Role already exists");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(RoleModels role)
        {
            bool roleId = await HttpRequestsHelper.Post<bool>(Environment.AccountApiUrl + "roles/update", role);
            return Ok(roleId);
        }
    }
}
