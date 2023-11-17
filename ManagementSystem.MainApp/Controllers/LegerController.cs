using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LegerController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "Leger/";


        [HttpPost("search_results")]
        public async Task<IActionResult> SearchLegers([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<LegerResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }
    }
}
