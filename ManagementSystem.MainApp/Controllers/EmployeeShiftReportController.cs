using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Components.Web;
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
        public async Task<IActionResult> SearchShiftHandovers([FromBody] SearchCriteria searchModel)
        {

           var result = await HttpRequestsHelper.Post<TPagination<ShiftHandoverResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
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

        [HttpPost("search_shift-end_reports")]
        public async Task<IActionResult> SearchShiftEndReports([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<TPagination<ShiftEndResponseDto>>(APIUrl + "search_shift-end_reports", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpGet("get-lastest-shift-end")]
        public async Task<IActionResult> GetLastestShiftEnd()
        {

            ResponseModel<ShiftEndResponseDto> response = new ResponseModel<ShiftEndResponseDto>();
            ShiftEndResponseDto detail = await HttpRequestsHelper.Get<ShiftEndResponseDto>(APIUrl + "get-lastest-shift-end");
            List <ShiftEndResponseDto> responseData = new List<ShiftEndResponseDto>();
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

        [HttpGet("get-shiftend-by-id")]
        public async Task<IActionResult> GetShiftEndById([FromQuery] int shiftEndId)
        {

            ResponseModel<ShiftEndResponseDto> response = new ResponseModel<ShiftEndResponseDto>();
            ShiftEndResponseDto detail = await HttpRequestsHelper.Get<ShiftEndResponseDto>(APIUrl + "get-shiftend-by-id?shiftEndId=" + shiftEndId);
            List<ShiftEndResponseDto> responseData = new List<ShiftEndResponseDto>();
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

        [HttpGet("check-completed-shift-end")]
        public async Task<IActionResult> CheckCompletedShiftEnd([FromQuery] int shiftId)
        {
            var result = await HttpRequestsHelper.Get<bool>(APIUrl + "check-completed-shift-end?shiftId=" + shiftId);

           return Ok(result);
        }
    }
}
