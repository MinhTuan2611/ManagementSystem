using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly INotificationsServices _serverSentEventsServices;

        public BillsController(INotificationsServices serverSentEventsServices)
        {
            _serverSentEventsServices = serverSentEventsServices;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<ListBillResponse> bills = await HttpRequestsHelper.Get<List<ListBillResponse>>(Environment.StorageApiUrl + "bills/get");
            if (bills != null || bills.Count > 0)
            {
                return Ok(bills);
            }
            return Ok("Bills not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BillInfo bill)
        {
            var response = await HttpRequestsHelper.Post<BillInfo>(Environment.StorageApiUrl + "bills/create", bill);
            if (response != null) 
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
        [HttpPost("complete-bill")]
        public async Task<IActionResult> CompleteBill(BillInfo bill)
        {
            var response = await HttpRequestsHelper.Post<bool>(Environment.StorageApiUrl + "bills/complete-bill", bill);
            if (response)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
        [HttpPost("momo-ipn")]
        public async Task<IActionResult> MomoIPN([FromBody] MomoRequestIPN request)
        {
            //var response = await HttpRequestsHelper.Post<bool>(Environment.StorageApiUrl + "bills/check-momo-payment", request);
            if (request.ResultCode == 0)
            {
                await _serverSentEventsServices.SendMessageAsync("MOMO_TRACKING", "1234", "Completed");
            } else
            {
                await _serverSentEventsServices.SendMessageAsync("MOMO_TRACKING", "1234", request.Message);
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
