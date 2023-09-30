using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos.Customers;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersService _CustomersService;
        private readonly IMapper _mapper;

        public CustomersController(StoragesDbContext context, IMapper mapper)
        {
            _CustomersService = new CustomersService(context);
            _mapper = mapper;
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
        public IActionResult Create([FromBody] NewCustomerRequestDto customerDto)
        {
            // Map customerDto to customer
            var newCustomer = _mapper.Map<Customer>(customerDto);

            // Add customer Metadata
            newCustomer.CreateBy = customerDto.UserId;
            newCustomer.ModifyBy = customerDto.UserId;

            var result = _CustomersService.CreateCustomer(newCustomer);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer, int userId)
        {
            bool updated = _CustomersService.UpdateCustomer(customer, userId);
            return Ok(updated);
        }

        [HttpPost("update_point")]
        public IActionResult UpdateCustomerPoint([FromBody] UpdateCustomerPointDto model)
        {
            bool updated = _CustomersService.UpdateCustomerPoint(model.Amount.Value, model.CustomerId.Value);
            return Ok(updated);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int customerId)
        {
            bool updated = _CustomersService.DeleteCustomer(customerId);
            return Ok(updated);
        }

        [HttpGet("search-term")]
        public IActionResult SearchCustomer([FromQuery] string searchTerm)
        {
            // Check search term input is empty or not
            string pattern = @"^[a-zA-Z0-9-]+$";
            Regex rg = new Regex(pattern);

            var customers = new List<Customer>();

            if (!rg.IsMatch(searchTerm)) // Search term is empty, we will get all customer
            {
                customers = _CustomersService.GetListCustomers();
            }
            else
            {
                customers = _CustomersService.GetCustomerBySearchTerm(searchTerm);
            }
            // Map Customer to CustomerDto to reponse
            var customerDto = _mapper.Map<List<CustomerResponseDto>>(customers);

            return Ok(customerDto);

        }
    }
}
