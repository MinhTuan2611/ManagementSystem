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
        public async Task<ResponseDto> GetAll(SearchCriteria searchModel)
        {
            var result = await _service.SearchReceipts(searchModel);
            return result;
        }

        [HttpGet("get-by-document-number")]
        public async Task<ResponseDto> GetByDocumentNumber([FromQuery] int DocumentNumber)
        {
            var result = await _service.GetReceptByDocumentNumber(DocumentNumber);
            return result;
        }

        [HttpPost("create")]
        public async Task<ResponseDto> Create(NewReceiptRequestDto request)
        {
            var result = await _service.CreateReceipt(request);

            return result;
        }

        [HttpPost("update")]
        public async Task<ResponseDto> Update(UpdateReceiptRequestDto request)
        {
            var updated = await _service.UpdateReceipt(request);
            return updated;
        }
    }
}
