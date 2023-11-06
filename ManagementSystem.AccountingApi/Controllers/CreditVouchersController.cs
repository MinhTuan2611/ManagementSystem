using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditVouchersController : ControllerBase
    {
        private readonly ICreditVoucherService _service;
        public CreditVouchersController(ICreditVoucherService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCreditVoucher([FromBody] NewCreditVoucherRequestDto requestDto)
        {
            var result = await _service.CreateCreditVoucher(requestDto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCreditVoucher([FromBody] UpdateCreditVoucherRequestDto requestDto)
        {
            var result = await _service.UpdateCreditVoucher(requestDto);

            return Ok(result);
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> GetAll(SearchCriteria searchModel)
        {
            var result = await _service.SearchCreditVouchers(searchModel);
            return Ok(result);
        }

        [HttpGet("get_detail")]
        public async Task<IActionResult> GetDetail(int documentNumber)
        {
            var result = await _service.GetCreditVouchereByDocumentNumber(documentNumber);
            return Ok(result);
        }
    }
}
