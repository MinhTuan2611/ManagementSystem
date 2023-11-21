using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryVoucherController : ControllerBase
    {
        private readonly IInventoryVoucherService _service;

        public InventoryVoucherController(IInventoryVoucherService service)
        {
            _service = service;
        }

        [HttpPost("search_results")]
        public async Task<IActionResult> SearchInventory([FromBody] SearchCriteria searchModel)
        {

            // Convert ValueKind.Object to the actual values
            foreach (var key in searchModel.Criterias.Keys.ToList())
            {
                if (searchModel.Criterias[key] is JsonElement jsonElement)
                {
                    searchModel.Criterias[key] = jsonElement.ToString();
                }
            }

            var response = await _service.SearchInventory(searchModel);

            if (response.Result != null)
            {
                var list = JsonConvert.DeserializeObject<TPagination<InventoryVoucherResponseDto>>(Convert.ToString(response.Result));
                return Ok(list);
            }

            return StatusCode(StatusCodes.Status404NotFound, response.Message);
        }

        [HttpGet("get-inventory-detail")]
        public async Task<IActionResult> GetDetail([FromQuery]int documentNumber)
        {

            var detail = await _service.GetInventoryDetailByDocumentNumber(documentNumber);


            if (detail.Result != null)
            {
                var response = JsonConvert.DeserializeObject<List<InventoryVoucherDetailResponseDto>>(Convert.ToString(detail.Result));
                return Ok(response);
            }
            return NotFound(detail);
        }

        [HttpGet("get-inventory-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int documentNumber)
        {
            var detail = await _service.GetInventoryByDocumentNumber(documentNumber);

            if (detail.Result != null)
            {
                var response = JsonConvert.DeserializeObject<InventoryVoucherResponseDto>(Convert.ToString(detail.Result));
                return Ok(response);
            }

            return NotFound(detail);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewInventoryVoucherDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await _service.CreateInventory(request);
            if (result.IsSuccess != null)
            { 
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateInventoryVoucherDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await _service.UpdateInventory(request);

            if (result.Result != null)
            {
                var response = JsonConvert.DeserializeObject<InventoryVoucher>(Convert.ToString(result.Result));
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}
