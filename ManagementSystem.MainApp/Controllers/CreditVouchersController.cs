using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Entities;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditVouchersController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "CreditVouchers/";

        [HttpPost("search_results")]
        public async Task<IActionResult> SearchInventory([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<CreditVoucherResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail([FromQuery] int documentNumber)
        {

            ResponseModel<CreditVoucherResponseDto> response = new ResponseModel<CreditVoucherResponseDto>();
            CreditVoucherResponseDto detail = await HttpRequestsHelper.Get<CreditVoucherResponseDto>(APIUrl + "get_detail?documentNumber=" + documentNumber);
            List<CreditVoucherResponseDto> responseData = new List<CreditVoucherResponseDto>();
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
        public async Task<IActionResult> Create(NewCreditVoucherRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<CreditVoucher>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateCreditVoucherRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await HttpRequestsHelper.Post<CreditVoucher>(APIUrl + "update", request);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status500InternalServerError, "System can not find the credit voucher or faild when update");
        }
    }
}
