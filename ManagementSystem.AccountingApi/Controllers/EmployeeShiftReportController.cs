using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

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
        public IActionResult CreateShiftEndReport([FromBody] NewEmployeeShiftEndRequestDto model)
        {
            var result = _service.CreateShiftEndReport(model);

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

        [HttpPost("search_shift-end_reports")]
        public async Task<IActionResult> SearchShiftEndReports([FromBody] SearchCriteria criteria)
        {
            var result = await _service.SearchShiftEndReports(criteria);

            return Ok(result);
        }

        [HttpGet("get-lastest-shift-end/{branchId}")]
        public async Task<IActionResult> GetLastestShiftEnd(int? branchId)
        {
            var result = await _service.GetLastestShiftEnd(branchId);

            return Ok(result);
        }

        [HttpGet("get-shiftend-by-id")]
        public async Task<IActionResult> GetShiftEndById([FromQuery] int shiftEndId)
        {
            var result = await _service.GetShiftEndById(shiftEndId);

            return Ok(result);
        }

        [HttpGet("get-shift-handover-by-id")]
        public async Task<IActionResult> GetShiftHandover([FromQuery] int handoverId)
        {
            var result = await _service.GetShiftHandover(handoverId);

            return Ok(result);
        }

        [HttpGet("check-completed-shift-end")]
        public async Task<IActionResult> CheckCompleteShiftEnd([FromQuery] int branchId)
        {
            var result = await _service.IsCompletedShiftEnd(branchId);

            return Ok(result);
        }
        [HttpGet("check-can-start-shift-end")]
        public async Task<IActionResult> CheckCanStartShiftEnd([FromQuery] int branchId)
        {
            var result = await _service.IsCanStartShiftEnd(branchId);

            return Ok(result);
        }
        [HttpGet("get-current-shift")]
        public async Task<IActionResult> GetCurrentShift([FromQuery] int branchId)
        {
            var result = await _service.GetCurrentShift(branchId);

            return Ok(result);
        }
        [HttpPost("start-shift-end")]
        public async Task<IActionResult> StartShiftEnd([FromBody] StartShiftEndRequestDto request)
        {
            var result = await _service.StartShiftEnd(request);

            return Ok(result);
        }

        [HttpGet("can-process-shift-end")]
        public async Task<IActionResult> CanProcessShiftEnd([FromQuery] int branchId)
        {
            var result = await _service.CanProcessShiftEnd(branchId);

            return Ok(result);
        }
    }
}
