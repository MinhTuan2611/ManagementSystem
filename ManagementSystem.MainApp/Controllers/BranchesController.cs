using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private string branchUrl = Environment.StorageApiUrl + "branches/";

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
        public async Task<IActionResult> Create(BranchInfo branch)
        {
            Branch branchPayload = new Branch
            {
                BranchCode = branch.BranchCode,
                BranchName = branch.BranchName,
                Address = branch.Address,
                PhoneNumber = branch.PhoneNumber,
                ManagerID = 1
            };
            Branch newBranch = await HttpRequestsHelper.Post<Branch>(branchUrl + "create", branchPayload);
            if (newBranch != null)
            {
                return Ok(newBranch);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateBranchModel updateBranch)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            updateBranch.UserId = Convert.ToInt32(userId);
            bool successfully = await HttpRequestsHelper.Post<bool>(branchUrl + "update", updateBranch);
            return Ok(successfully);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int branchId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            BranchRequest request = new BranchRequest
            {
                UserId = userId,
                BranchId = branchId
            };

            bool successfully = await HttpRequestsHelper.Post<bool>(branchUrl + "delete", request);
            return Ok(successfully);
        }
    }
}
