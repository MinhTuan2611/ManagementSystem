using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly BillsService _BillsService;

        public BillsController(StoragesDbContext context)
        {
            _BillsService = new BillsService(context);
        }
        [HttpGet("get")]
        public List<ListBillResponse> Get()
        {
            var bills = _BillsService.GetListBills();
            return bills;
        }
       
        [HttpPost("create")]
        public IActionResult Create(BillInfo bill)
        {
            var result = _BillsService.CreateBill(bill);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when create bill!");
        }
        [HttpPost("complete-bill")]
        public IActionResult CompleteBill(BillInfo bill)
        {
            var response = _BillsService.CompleteBill(bill);
            if (response)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("check-momo-payment")]
        public IActionResult CompleteBill(MomoRequestIPN request)
        {
            var response = _BillsService.CheckMomoPayment(request);
            return Ok(response);
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> SearchBills([FromBody] SearchCriteria criteria)
        {
            var result = await _BillsService.SearchBills(criteria);

            return Ok(result);
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetBillDetail([FromQuery] int billId)
        {
            var result = await _BillsService.GetBillDetail(billId);

            return Ok(result);
        }
    }
}
