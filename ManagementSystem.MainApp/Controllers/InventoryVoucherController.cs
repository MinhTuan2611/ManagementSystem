using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
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
