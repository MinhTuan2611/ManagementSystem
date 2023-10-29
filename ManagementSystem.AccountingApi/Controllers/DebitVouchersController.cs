using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitVouchersController : ControllerBase
    {
        private readonly IDebitVoucherService _service;

        public DebitVouchersController(IDebitVoucherService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDebitVoucher([FromBody] NewDebitVoucherRequestDto model)
        {
            var result = await _service.CreateDebitVoucher(model);
            
            return Ok(result);
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> GetAll(SearchCriteria searchModel)
        {
            var result = await _service.GetAllDebitVouchers(searchModel);
            return Ok(result);
        }

        [HttpGet("get_detail")]
        public async Task<IActionResult> GetDetail(int documentNumber)
        {
            var result = await _service.GetDebitVouchereByDocumentNumber(documentNumber);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateDebitVoucher([FromBody] UpdateDebitVoucherRequestDto requestDto)
        {
            var result = await _service.UpdateDebitVoucher(requestDto);

            return Ok(result);
        }
    }
}
