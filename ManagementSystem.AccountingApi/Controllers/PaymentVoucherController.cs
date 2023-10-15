using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentVoucherController : ControllerBase
    {
        private readonly IPaymentVoucherService _service;

        public PaymentVoucherController(IPaymentVoucherService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPaymentVouchers([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {
            var result = await _service.GetPaymentVouchers();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetPaymentVoucher([FromQuery] int documentNumber)
        {
            var result = await _service.GetPaymentVoucher(documentNumber);

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePaymentVoucher([FromBody] NewPaymentVoucherDto newPaymentVoucher)
        {
             var result = await _service.CreatePaymentVoucher(newPaymentVoucher);
             return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdatePaymentVoucher([FromBody] UpdatePaymentVoucherDto updatePaymentVoucher)
        {
            var  result = await _service.UpdatePaymentVoucher(updatePaymentVoucher);
            return Ok(result);
        }

    }
}
