using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private string branchUrl = Environment.AccountApiUrl + "branches/";
        [HttpGet("get")]
        public async Task<IActionResult> Get(string? searchValue)
        {
            LsBranchRes response = new LsBranchRes();
            List<Branch> lsBranches = await HttpRequestsHelper.Get<List<Branch>>(branchUrl + "get");
            if (lsBranches != null)
            {

                response.Status = "success";
                response.Branches = lsBranches;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Branch branch)
        {
            Branch newBranch = await HttpRequestsHelper.Post<Branch>(branchUrl + "create", branch);
            if (newBranch != null)
            {
                return Ok(newBranch);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }
}
