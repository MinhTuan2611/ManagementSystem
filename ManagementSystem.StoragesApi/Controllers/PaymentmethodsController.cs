using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly PaymentMethodsService _PaymentMethodsService;

        public PaymentMethodsController(StoragesDbContext context)
        {
            _PaymentMethodsService = new PaymentMethodsService(context);
        }
        [HttpGet("get")]
        public List<PaymentMethod> Get()
        {
            var paymentMethods = _PaymentMethodsService.GetListPaymentMethod();
            return paymentMethods;
        }
        [HttpPost("create")]
        public IActionResult Create(PaymentMethod paymentMethod)
        {
            var newMethod = _PaymentMethodsService.CreatePaymentMethod(paymentMethod);
            if (newMethod != null)
            {
                return Ok(newMethod);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpGet("GetByCode")]
        public IActionResult GetByCode(string code)
        {
            var result = _PaymentMethodsService.GetPaymentByCode(code);
            return Ok(result);
        }
    }
}
