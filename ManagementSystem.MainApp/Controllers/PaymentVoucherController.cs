using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentVoucherController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "PaymentVoucher/";

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {

            ResponseModel<PaymentVoucherResponseDto> response = new ResponseModel<PaymentVoucherResponseDto>();
            List<PaymentVoucherResponseDto> products = await HttpRequestsHelper.Get<List<PaymentVoucherResponseDto>>(APIUrl + "get");
            if (products != null)
            {

                response.Status = "success";
                response.Data = products;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail(int? documentNumber)
        {

            ResponseModel<PaymentVoucherResponseDto> response = new ResponseModel<PaymentVoucherResponseDto>();
            PaymentVoucherResponseDto detail = await HttpRequestsHelper.Get<PaymentVoucherResponseDto>(APIUrl + "get-by-id?documentNumber=" + documentNumber);
            List<PaymentVoucherResponseDto> responseData = new List<PaymentVoucherResponseDto>();
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
        public async Task<IActionResult> Create(NewPaymentVoucherDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var isCreated = await HttpRequestsHelper.Post<PaymentVoucher>(APIUrl + "create", request);
            if (isCreated != null)
            {
                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when create Payment Voucher!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdatePaymentVoucherDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);
            var result = await HttpRequestsHelper.Post<OtherAccountEntry>(APIUrl + "update", request);

            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when update Other Account entry!");
        }
    }
}
