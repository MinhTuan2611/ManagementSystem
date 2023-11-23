using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _service;

        public ReceiptController(IReceiptService service)
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

            var response = await _service.SearchReceipts(searchModel);

            if (response.Result != null)
            {
                var list = JsonConvert.DeserializeObject<TPagination<ReceiptResponseDto>>(Convert.ToString(response.Result));
                return Ok(list);
            }

            return StatusCode(StatusCodes.Status404NotFound, response.Message);
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail([FromQuery] int documentNumber)
        {

            var detail = await _service.GetReceiptByDocumentNumber(documentNumber);

            if (detail.Result != null)
            {
                var response = JsonConvert.DeserializeObject<ReceiptResponseDto>(Convert.ToString(detail.Result));
                return Ok(response);
            }

            return NotFound(detail);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(NewReceiptRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await _service.CreateReceipt(request);

            if (result.Result != null)
            {
                var response = JsonConvert.DeserializeObject<ReceiptVoucher>(Convert.ToString(result.Result));
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateReceiptRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await _service.UpdateReceipt(request);

            if (result.Result != null)
            {
                var response = JsonConvert.DeserializeObject<ReceiptVoucher>(Convert.ToString(result.Result));
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}
