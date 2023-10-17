using ManagementSystem.AccountingApi.Services;
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
    }
}
