

using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private IRefundService _refundService;

        public RefundController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateRefundBill(BillRefundRequestDto model)
        {

            await _refundService.CreateRefundVoucher(model);
            return Ok(model);
        }
    }
}