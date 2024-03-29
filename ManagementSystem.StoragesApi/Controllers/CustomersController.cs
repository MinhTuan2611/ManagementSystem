﻿using AutoMapper;
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

        [HttpGet("get-customer-by-id")]
        public Customer GetCustomerById(int customerId)
        {
            var customer = _CustomersService.GetCustomerById(customerId);
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
            newCustomer.IsActive = true;
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

        [HttpDelete("delete/{customerId}/{actionUserId}")]
        public IActionResult Delete(int customerId, int actionUserId)
        {
            bool deleted = _CustomersService.DeleteCustomer(customerId, actionUserId);
            return Ok(deleted);
        }

        [HttpGet("search-term")]
        public IActionResult SearchCustomer([FromQuery] string searchTerm)
        {
            var customers = _CustomersService.GetCustomerBySearchTerm(searchTerm);
            return Ok(customers);
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var customers = _CustomersService.GetCustomerById(id);
            return Ok(customers);
        }
    }
}
