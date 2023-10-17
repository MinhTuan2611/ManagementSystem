using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftReportController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "EmployeeShiftReport/";
        [HttpPost("create")]
        public async Task<IActionResult> Create(NewEmployeeShiftEndRequestDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<EmployeeShift>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }
}
