using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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

            var result = await HttpRequestsHelper.Post<ResponseDto>(APIUrl + "search_results", searchModel);

            if (result.Result != null)
            {
                return Ok(result.Result);
            }

            return StatusCode(StatusCodes.Status404NotFound, result.Message);
        }

        [HttpGet("get-inventory-detail")]
        public async Task<IActionResult> GetDetail([FromQuery]int documentNumber)
        {

            var detail = await HttpRequestsHelper.Get<ResponseDto>(APIUrl + "get-detail-by-document-number?documentNumber=" + documentNumber);


            if (detail.Result != null)
            {
                return Ok(detail);
            }
            return NotFound(detail);
        }

        [HttpGet("get-inventory-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int documentNumber)
        {
            var detail = await HttpRequestsHelper.Get<ResponseDto>(APIUrl + "get-by-document-number?documentNumber=" + documentNumber);

            if (detail != null)
            {
                return Ok(detail);
            }

            return NotFound(detail);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewInventoryVoucherDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<ResponseDto>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateInventoryVoucherDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await HttpRequestsHelper.Post<ResponseDto>(APIUrl + "update", request);

            if (result.Result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}
