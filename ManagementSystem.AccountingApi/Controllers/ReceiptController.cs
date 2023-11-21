using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _service;

        public ReceiptController(IReceiptService service)
        {
            _service = service;
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> GetAll(SearchCriteria searchModel)
        {
            var result = await _service.SearchReceipts(searchModel);
            return Ok(result);
        }

        [HttpGet("get-by-document-number")]
        public async Task<IActionResult> GetByDocumentNumber([FromQuery] int DocumentNumber)
        {
            var result = await _service.GetReceptByDocumentNumber(DocumentNumber);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewReceiptRequestDto request)
        {
            var result = await _service.CreateReceipt(request);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateReceiptRequestDto request)
        {
            var updated = await _service.UpdateReceipt(request);
            return Ok(updated);
        }
    }
}
