using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftReportController : ControllerBase
    {
        private string APIUrl = SD.AccountingApiUrl + "EmployeeShiftReport/";

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewEmployeeShiftEndRequestDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<bool>(APIUrl + "create", request);
            if (result)
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

        [HttpGet("get-lastest-shift-end/{branchId}")]
        public async Task<IActionResult> GetLastestShiftEnd(int? branchId)
        {

            ResponseModel<ShiftEndResponseDto> response = new ResponseModel<ShiftEndResponseDto>();
            ShiftEndResponseDto detail = await HttpRequestsHelper.Get<ShiftEndResponseDto>(APIUrl + "get-lastest-shift-end/" + branchId);
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
        public async Task<IActionResult> CheckCompletedShiftEnd([FromQuery] int branchId)
        {
            var result = await HttpRequestsHelper.Get<int>(APIUrl + "check-completed-shift-end?branchId=" + branchId);

           return Ok(result);
        }
        [HttpGet("check-can-start-shift-end")]
        public async Task<IActionResult> CheckCanStartShiftEnd([FromQuery] int branchId)
        {
            var result = await HttpRequestsHelper.Get<bool>(APIUrl + "check-can-start-shift-end?branchId=" + branchId);

            return Ok(result);
        }
        [HttpGet("get-current-shift")]
        public async Task<IActionResult> GetCurrentShift([FromQuery] int branchId)
        {
            var result = await HttpRequestsHelper.Get<int>(APIUrl + "get-current-shift?branchId=" + branchId);

            return Ok(result);
        }
        [HttpPost("start-shift-end")]
        public async Task<IActionResult> StartShiftEnd([FromBody] StartShiftEndRequestDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);
            var result = await HttpRequestsHelper.Post<ResponsePagingModel<ShiftEndReport>>(APIUrl + "start-shift-end", request);
            return Ok(result);
        }

        [HttpGet("can-process-shift-end")]
        public async Task<IActionResult> CanProcessShiftEnd([FromQuery] int branchId)
        {
            var result = await HttpRequestsHelper.Get<bool>(APIUrl + "can-process-shift-end?branchId=" + branchId);

            return Ok(result);
        }
    }
}
