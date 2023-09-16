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
        private readonly IServerSentEventsServices _serverSentEventsServices;

        public BillsController(IServerSentEventsServices serverSentEventsServices)
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
        [HttpPost("momo-ipn")]
        public async Task<IActionResult> MomoIPN()
        {
            await _serverSentEventsServices.SendMessageAsync("MOMO_TRACKING", "1234", "Completed");
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
    }
}
