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
    public class SuppliersController : ControllerBase
    {
        private string APIUrl = Environment.StorageApiUrl + "suppliers/";
        [HttpGet("get")]
        public async Task<IActionResult> Get(string? searchValue)
        {

            LsSuppllerRes response = new LsSuppllerRes();
            List<Supplier> lsSuppliers = await HttpRequestsHelper.Get<List<Supplier>>(APIUrl + "get");
            if (lsSuppliers != null)
            {

                response.Status = "success";
                response.Data = lsSuppliers;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(SupplierInfo supplier)
        {
            Supplier branchPayload = new Supplier
            {
                SupplierCode = supplier.SupplierCode,
                SupplierName = supplier.SupplierName,
                DisplayName = supplier.DisplayName,
                Address = supplier.Address,
                Phone = supplier.Phone
            };
            Supplier newBranch = await HttpRequestsHelper.Post<Supplier>(APIUrl + "create", branchPayload);
            if (newBranch != null)
            {
                return Ok(newBranch);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateSupplierModel updateSupplier)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            updateSupplier.UserId = Convert.ToInt32(userId);
            bool successfully = await HttpRequestsHelper.Post<bool>(APIUrl + "update", updateSupplier);
            return Ok(successfully);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int supplierId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            BranchRequest request = new BranchRequest
            {
                UserId = userId,
                BranchId = supplierId
            };

            bool successfully = await HttpRequestsHelper.Post<bool>(APIUrl + "delete", request);
            return Ok(successfully);
        }
    }
}
