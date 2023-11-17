using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        [HttpGet("get_payment_methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = new LsPaymentMethodsRes();
            var result = await HttpRequestsHelper.Get<List<PaymentMethod>>(SD.StorageApiUrl + "PaymentMethods/get");
            if (result != null)
            {

                response.Status = "success";
                response.PaymentMethods = result;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
