using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet("get-customer-by-code")]
        public async Task<IActionResult> Get(string customerCode)
        {
            Customer customer = await HttpRequestsHelper.Get<Customer>(Environment.StorageApiUrl + "customers/get-customer-by-code?customerCode=" + customerCode);
            if (customer != null)
            {
                return Ok(customer);
            }
            return Ok("Customer not found");
        }
    }
}
