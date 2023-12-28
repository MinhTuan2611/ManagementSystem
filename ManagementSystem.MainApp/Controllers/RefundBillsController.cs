using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Entities;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RefundBillsController : ControllerBase
    {
        private string APIUrl = SD.AccountingApiUrl + "RefundBills/";
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BillRefundRequestDto model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            model.UserId = int.Parse(userId);

            var resultBill = await HttpRequestsHelper.Post<object>(APIUrl + "create", model);
            if (resultBill != null)
                return Ok(resultBill);

            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }


    }
}
