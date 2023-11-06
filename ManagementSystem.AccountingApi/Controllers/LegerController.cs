using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegerController : ControllerBase
    {
        private ILegerService _legerService;

        public LegerController(ILegerService legerService)
        {
            _legerService = legerService;
        }

        [HttpPost]
        [Route("search_results")]
        public async Task<IActionResult> SearchLegers([FromBody] SearchCriteria searchModel)
        {
            var result = await _legerService.GetAllLegerInformation(searchModel);
            return Ok(result);
        }
    }
}
