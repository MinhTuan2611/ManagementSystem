using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos.Accounting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherAccountEntryController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "OtherAccountEntry/";

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {

            ResponseModel<OtherAccountEntryResponseDto> response = new ResponseModel<OtherAccountEntryResponseDto>();
            List<OtherAccountEntryResponseDto> products = await HttpRequestsHelper.Get<List<OtherAccountEntryResponseDto>>(APIUrl + "get");
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

            ResponseModel<OtherAccountEntryResponseDto> response = new ResponseModel<OtherAccountEntryResponseDto>();
            OtherAccountEntryResponseDto detail = await HttpRequestsHelper.Get<OtherAccountEntryResponseDto>(APIUrl + "get-by-id?documentNumber=" + documentNumber);
            List<OtherAccountEntryResponseDto> responseData = new List<OtherAccountEntryResponseDto>();
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
        public async Task<IActionResult> Create(NewOtherAccountEntrydto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<OtherAccountEntry>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when create Other Account entry!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateOtherAccountEntryDto request)
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
