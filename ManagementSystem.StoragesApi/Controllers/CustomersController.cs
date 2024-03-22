using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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

        public CustomersController(StoragesDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _CustomersService = new CustomersService(context, configuration);
            _mapper = mapper;
        }
        [HttpGet("get")]
        public TPagination<Customer> Get(string? customerName, string? phoneNumber, int pageSize = 10, int pageNumber = 1)
        {
            var (customers, countCustomer) = _CustomersService.GetListCustomers(customerName, phoneNumber, pageSize, pageNumber);

            var result = new TPagination<Customer>();
            result.TotalItems = countCustomer;
            result.Items = customers;

            return result;
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
            if (_CustomersService.checkExistCustomer(newCustomer))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer already exists!");
            }
            var result = _CustomersService.CreateCustomer(newCustomer);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("check-exists")]
        public IActionResult Exists([FromBody] NewCustomerRequestDto customerDto)
        {
            // Map customerDto to customer
            var newCustomer = _mapper.Map<Customer>(customerDto);
            if (_CustomersService.checkExistCustomer(newCustomer))
            {
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost("update/{actionUserId}")]
        public async Task<IActionResult> Update([FromBody] Customer customer, int actionUserId)
        {
            if (customer == null)
                return BadRequest("Invalid model");

            bool updated = await _CustomersService.UpdateCustomer(customer, actionUserId);
            if (updated == true)
                return Ok(updated);

            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update_point")]
        public IActionResult UpdateCustomerPoint([FromBody] UpdateCustomerPointDto model)
        {
            bool updated = _CustomersService.UpdateCustomerPoint(model.Amount.Value, model.CustomerId.Value, model.UsedPoint ?? 0);
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
            var customers = _CustomersService.GetCustomerBySearchTerm(searchTerm);
            return Ok(customers);
        }
    }
}
