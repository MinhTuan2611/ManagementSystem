using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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

        [HttpPost("search_results")]
        public async Task<IActionResult> Create([FromBody] SearchCriteria searchModel)
        {

            ResponseModel<ShiftHandoverResponseDto> response = new ResponseModel<ShiftHandoverResponseDto>();
            List<ShiftHandoverResponseDto> result = await HttpRequestsHelper.Post<List<ShiftHandoverResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
            {

                response.Status = "success";
                response.Data = result;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get-shift-report")]
        public async Task<IActionResult> GetDetail([FromQuery] int shiftEndId)
        {

            ResponseModel<ShiftReportResponseDto> response = new ResponseModel<ShiftReportResponseDto>();
            ShiftReportResponseDto detail = await HttpRequestsHelper.Get<ShiftReportResponseDto>(APIUrl + "get-shift-report?shiftEndId=" + shiftEndId);
            List<ShiftReportResponseDto> responseData = new List<ShiftReportResponseDto>();
            responseData.Add(detail);

            if (detail != null)
            {

                response.Status = "success";
                response.Data = responseData;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get-shift-handover-by-id")]
        public async Task<IActionResult> GetShiftHandover([FromQuery] int handoverId)
        {

            ResponseModel<ShiftHandoverResponseDto> response = new ResponseModel<ShiftHandoverResponseDto>();
            ShiftHandoverResponseDto detail = await HttpRequestsHelper.Get<ShiftHandoverResponseDto>(APIUrl + "get-shift-handover-by-id?handoverId=" + handoverId);
            List<ShiftHandoverResponseDto> responseData = new List<ShiftHandoverResponseDto>();
            responseData.Add(detail);

            if (detail != null)
            {

                response.Status = "success";
                response.Data = responseData;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
