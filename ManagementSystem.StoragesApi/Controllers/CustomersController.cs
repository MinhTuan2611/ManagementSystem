using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersService _CustomersService;

        public CustomersController(StoragesDbContext context)
        {
            _CustomersService = new CustomersService(context);
        }
        [HttpGet("get")]
        public List<Customer> Get()
        {
            var customers = _CustomersService.GetListCustomers();
            return customers;
        }
        [HttpGet("get-customer-by-code")]
        public Customer GetCustomerByCode(string customerCode)
        {
            var customer = _CustomersService.GetCustomerByCode(customerCode);
            return customer;
        }
        [HttpPost("create")]
        public IActionResult Create(Customer customer)
        {
            var newCustomer = _CustomersService.CreateCustomer(customer);
            if (newCustomer != null)
            {
                return Ok(newCustomer);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer, int userId)
        {
            bool updated = _CustomersService.UpdateCustomer(customer, userId);
            return Ok(updated);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int customerId)
        {
            bool updated = _CustomersService.DeleteCustomer(customerId);
            return Ok(updated);
        }
    }
}
