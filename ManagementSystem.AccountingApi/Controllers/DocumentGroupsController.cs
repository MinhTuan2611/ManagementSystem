using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentGroupsController : ControllerBase
    {
        private IDocumentGroupService _legerService;

        public DocumentGroupsController(IDocumentGroupService legerService)
        {
            _legerService = legerService;
        }

        [HttpPost]
        [Route("search_results")]
        public async Task<IActionResult> SearchDocumentGroups([FromBody] SearchCriteria searchModel)
        {
            var result = await _legerService.GetAllLegerInformation(searchModel);
            return Ok(result);
        }
    }
}
