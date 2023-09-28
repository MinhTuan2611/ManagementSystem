using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "Receipt/";

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {

            ResponseModel<ReceiptResponseDto> response = new ResponseModel<ReceiptResponseDto>();
            List<ReceiptResponseDto> vouchers = await HttpRequestsHelper.Get<List<ReceiptResponseDto>>(APIUrl + "get-all?page=" + page + "&pageSize=" + pageSize);

            if (vouchers != null)
            {

                response.Status = "success";
                response.Data = vouchers;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail([FromQuery] int documentNumber)
        {

            ResponseModel<ReceiptResponseDto> response = new ResponseModel<ReceiptResponseDto>();
            ReceiptResponseDto detail = await HttpRequestsHelper.Get<ReceiptResponseDto>(APIUrl + "get-by-document-number?documentNumber=" + documentNumber);
            List<ReceiptResponseDto> responseData = new List<ReceiptResponseDto>();
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


        [HttpPost("create")]
        public async Task<IActionResult> Create(NewReceiptRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            bool isCreated = await HttpRequestsHelper.Post<bool>(APIUrl + "create", request);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateReceiptRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            bool successfully = await HttpRequestsHelper.Post<bool>(APIUrl + "update", request);

            if (successfully)
                return Ok(successfully);

            return StatusCode(StatusCodes.Status500InternalServerError, "System can not find the inventory or faild when update");
        }
    }
}
