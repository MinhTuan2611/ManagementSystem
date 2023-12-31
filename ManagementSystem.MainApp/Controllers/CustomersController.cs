﻿using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.CustomerActionFilters;
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
            ResponseModel<Customer> response = new ResponseModel<Customer>();
            List<Customer> customers = await HttpRequestsHelper.Get<List<Customer>>(Environment.StorageApiUrl + "customers/get-customer-by-code?customerCode=" + customerCode);

            if (customers != null)
            {
                return Ok(customers);
            }
            return Ok("Customer not found");
        }

        [HttpPost]
        [Route("create-customer")]
        [ValidateModel]
        public async Task<IActionResult> CreateCustomer([FromBody] NewCustomerRequestDto customerDto)
        {

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            customerDto.UserId = userId;

            // Call Api creating
            var checkExistsCustomer = await HttpRequestsHelper.Post<bool>(Environment.StorageApiUrl + "customers/check-exists", customerDto);
            if (checkExistsCustomer)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer already exists!");
            }
            var customer = await HttpRequestsHelper.Post<Customer>(Environment.StorageApiUrl + "customers/create", customerDto);
            if (customer != null)
            {
                return Ok(customer);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

        [HttpGet]
        [Route("search-term")]
        public async Task<IActionResult> GetCustomerBySearchTerm([FromQuery] string? searchTerm)
        {
            List<CustomerResponseDto> customers = await HttpRequestsHelper.GetList<CustomerResponseDto>(Environment.StorageApiUrl + "customers/search-term?searchTerm=" + searchTerm);

            if (customers.Count == 0)
                return BadRequest("Customers not found");

            return Ok(customers);

        }
    }
}
