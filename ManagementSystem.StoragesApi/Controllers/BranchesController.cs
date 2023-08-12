using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchesService _BranchesService;

        public BranchesController(StoragesDbContext context)
        {
            _BranchesService = new BranchesService(context);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var branches = _BranchesService.GetListBranches();
            if (branches != null)
            {
                var lsBranches = branches as List<Branch> ?? branches.ToList();
                if (lsBranches.Any())
                    return Ok(lsBranches);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        [HttpPost("create")]
        public IActionResult Create(Branch branch)
        {
            var newBranch = _BranchesService.CreateBranch(branch);
            if (newBranch != null)
            {
                return Ok(newBranch);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateBranchModel branch)
        {
            bool updated = _BranchesService.UpdateBranch(branch.BranchId, branch.Branch);
            return Ok(updated);
        }
    }
}
