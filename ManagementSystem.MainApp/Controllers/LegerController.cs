using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegerController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "Leger/";

        [HttpPost("search_results")]
        public async Task<IActionResult> Create([FromBody] SearchCriteria searchModel)
        {

            ResponseModel<LegerResponseDto> response = new ResponseModel<LegerResponseDto>();
            List<LegerResponseDto> result = await HttpRequestsHelper.Post<List<LegerResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
            {

                response.Status = "success";
                response.Data = result;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
