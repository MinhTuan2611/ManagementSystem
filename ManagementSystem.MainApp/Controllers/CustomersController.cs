using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.CustomerActionFilters;
using ManagementSystem.MainApp.Utility;
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

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {

            ResponseModel<CustomerResponseDto> response = new ResponseModel<CustomerResponseDto>();
            var result = await HttpRequestsHelper.Get<CustomerResponseDto>(SD.StorageApiUrl + "customers/get-detail?id=" + id);

            var resultResponse = new List<CustomerResponseDto>();
            resultResponse.Add(result);

            if (result != null)
            {

                response.Status = "success";
                response.Data = resultResponse;
                return Ok(response);
            }

            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
