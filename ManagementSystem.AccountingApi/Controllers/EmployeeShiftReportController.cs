using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftReportController : ControllerBase
    {
        private readonly IEmployeeShiftReportService _service;

        public EmployeeShiftReportController(IEmployeeShiftReportService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateShiftEndReport([FromBody] NewEmployeeShiftEndRequestDto model)
        {
            var result = await _service.CreateShiftEndReport(model);

            return Ok(result != null ? true: false);
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> SearchShiftHandover([FromBody] SearchCriteria criteria)
        {
            var result = await _service.GetAllShiftHandover(criteria);

            return Ok(result);
        }

        [HttpGet("get-shift-report")]
        public async Task<IActionResult> GetShiftReport([FromQuery] int shiftEndId)
        {
            var result = await _service.GetShiftReport(shiftEndId);

            return Ok(result);
        }

        [HttpGet("get-shift-handover-by-id")]
        public async Task<IActionResult> GetShiftHandover([FromQuery] int handoverId)
        {
            var result = await _service.GetShiftHandover(handoverId);

            return Ok(result);
        }

    }
}
