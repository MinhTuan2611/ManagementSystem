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
    public class InventoryVoucherController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "InventoryVoucher/";


        [HttpPost("search_results")]
        public async Task<IActionResult> SearchInventory([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<InventoryVoucherResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpGet("get-inventory-detail")]
        public async Task<IActionResult> GetDetail([FromQuery]int documentNumber)
        {

            ResponseModel<InventoryVoucherDetailResponseDto> response = new ResponseModel<InventoryVoucherDetailResponseDto>();
            var detail = await HttpRequestsHelper.Get<List<InventoryVoucherDetailResponseDto>>(APIUrl + "get-detail-by-document-number?documentNumber=" + documentNumber);


            if (detail != null)
            {

                response.Status = "success";
                response.Data = detail;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get-inventory-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int documentNumber)
        {

            ResponseModel<InventoryVoucherResponseDto> response = new ResponseModel<InventoryVoucherResponseDto>();
            var detail = await HttpRequestsHelper.Get<InventoryVoucherResponseDto>(APIUrl + "get-by-document-number?documentNumber=" + documentNumber);

            List<InventoryVoucherResponseDto> result = new List<InventoryVoucherResponseDto>();
            result.Add(detail);

            if (detail != null)
            {

                response.Status = "success";
                response.Data = result;
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

            var result = await HttpRequestsHelper.Post<InventoryVoucher>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
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
