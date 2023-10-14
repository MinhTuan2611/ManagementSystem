using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {
            var result = await _service.GetAllReceipts(page.Value, pageSize.Value);
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
