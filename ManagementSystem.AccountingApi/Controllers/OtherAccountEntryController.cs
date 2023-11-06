using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherAccountEntryController : ControllerBase
    {
        private readonly IOtherAccountEntryService _service;

        public OtherAccountEntryController(IOtherAccountEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOtherAccountEntries([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {
            var result = await _service.GetOtherAccountEntries(page, pageSize);

            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetOtherAccountEntry([FromQuery] int documentNumber)
        {
            var result = await _service.GetOtherAccountEntry(documentNumber);

            return Ok(result);
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOtherAccountEntry([FromBody] NewOtherAccountEntrydto newOtherAccountEntrydto)
        {
            var result = await _service.CreateAccountEntry(newOtherAccountEntrydto);
            return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateOtherAccountEntry([FromBody] UpdateOtherAccountEntryDto updateOtherAccountEntryDto)
        {
            var result = await _service.UpdateAccountEntry(updateOtherAccountEntryDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("search_results")]
        public async Task<IActionResult> SearchOtherEntriess([FromBody] SearchCriteria searchModel)
        {
            var result = await _service.SearchOtherAccountEntries(searchModel);
            return Ok(result);
        }
    }
}
