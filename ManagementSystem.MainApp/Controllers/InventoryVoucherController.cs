using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryVoucherController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "InventoryVoucher/";

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {

            ResponseModel<InventoryVoucherResponseDto> response = new ResponseModel<InventoryVoucherResponseDto>();
            List<InventoryVoucherResponseDto> vouchers = await HttpRequestsHelper.Get<List<InventoryVoucherResponseDto>>(APIUrl + "get-all?page=" + page + "&pageSize=" + pageSize);

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
        public async Task<IActionResult> GetDetail([FromQuery]int documentNumber)
        {

            ResponseModel<List<InventoryVoucherResponseDto>> response = new ResponseModel<List<InventoryVoucherResponseDto>>();
            List<InventoryVoucherResponseDto> detail = await HttpRequestsHelper.Get<List<InventoryVoucherResponseDto>>(APIUrl + "get-by-document-number?documentNumber=" + documentNumber);
            List<List<InventoryVoucherResponseDto>> responseData = new List<List<InventoryVoucherResponseDto>>();
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
        public async Task<IActionResult> Create(NewInventoryVoucherDto request)
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
        public async Task<IActionResult> Update(UpdateInventoryVoucherDto request)
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
