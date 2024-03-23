using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
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

        [HttpGet("get")]
        public async Task<IActionResult> Get(string? customerName, string? phoneNumber, int? pageSize = 10, int? pageNumber = 1)
        {
            var result = await HttpRequestsHelper.Get<TPagination<Customer>>(Environment.StorageApiUrl
                + "customers/get?pageSize=" + pageSize
                + "&pageNumber=" + pageNumber
                + (!String.IsNullOrEmpty(customerName) ? "&customerName=" + customerName : "")
                + (!String.IsNullOrEmpty(phoneNumber) ? "&phoneNumber=" + phoneNumber : "")
                );

            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

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

        [HttpGet("get-customer-by-id")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            Customer customers = await HttpRequestsHelper.Get<Customer>(Environment.StorageApiUrl + "customers/get-customer-by-id?customerId=" + customerId);

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

            if (customers?.Count == 0)
                return BadRequest("Customers not found");

            return Ok(customers);

        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            int actionUserId = int.Parse(userId);

            var response = await HttpRequestsHelper.Post<bool>(Environment.StorageApiUrl + $"customers/update/{actionUserId}", customer);
            if (response)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            int actionUserId = int.Parse(userId);

            var response = await HttpRequestsHelper.Delete<bool>(Environment.StorageApiUrl + $"customers/delete/{customerId}/{actionUserId}", customerId);
            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
    }
}
