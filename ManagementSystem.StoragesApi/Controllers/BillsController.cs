﻿using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly BillsService _BillsService;

        public BillsController(StoragesDbContext context)
        {
            _BillsService = new BillsService(context);
        }
        [HttpGet("get")]
        public List<ListBillResponse> Get()
        {
            var bills = _BillsService.GetListBills();
            return bills;
        }
       
        [HttpPost("create")]
        public IActionResult Create(BillInfo bill)
        {
            var response = _BillsService.CreateBill(bill);
            if (response != null)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("complete-bill")]
        public IActionResult CompleteBill(BillInfo bill)
        {
            var response = _BillsService.CompleteBill(bill);
            if (response)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }
}
