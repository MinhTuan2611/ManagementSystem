using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.CustomerActionFilters;
using ManagementSystem.MainApp.Dtos;
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
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        [HttpPost]
        [Route("create-customer")]
        [ValidateModel]
        public async Task<IActionResult> CreateCustomer([FromBody] NewCustomerRequestDto customerDto)
        {

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

            // Map customerDto to customer
            var newCustomer = _mapper.Map<Customer>(customerDto);

            // Add customer Metadata
            newCustomer.CreateBy = userId;
            newCustomer.CreateDate = DateTime.Now;
            newCustomer.ModifyBy = userId;
            newCustomer.ModifyDate = DateTime.Now;

            // Call Api creating
            var customer = await HttpRequestsHelper.Post<Customer>(Environment.StorageApiUrl + "customers/create", newCustomer);
            if (customer != null)
            {
                return Ok(customer);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

        [HttpGet]
        [Route("search-term")]
        public async Task<IActionResult> GetCustomerBySearchTerm([FromQuery] string searchTerm)
        {
            List<Customer> customers = await HttpRequestsHelper.GetList<Customer>(Environment.StorageApiUrl + "customers/search-term?searchTerm=" + searchTerm.ToLower());

            if (customers.Count == 0)
                return BadRequest("Customers not found");

            // Map Customer to CustomerDto to reponse
            var customerDto = _mapper.Map<List<CustomerResponseDto>>(customers);

            return Ok(customerDto);

        }
    }
}
