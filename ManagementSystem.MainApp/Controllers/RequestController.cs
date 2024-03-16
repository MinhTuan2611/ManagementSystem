using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            ResponsePagingModel<ResponseRequestDto> response = new ResponsePagingModel<ResponseRequestDto>();
            var requets = await HttpRequestsHelper.Get<ResponseRequestDto>(SD.StorageApiUrl + "Request");
            if (requets != null)
            {
                response.Status = "success";
                response.Data = requets;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get_by_id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var request = await HttpRequestsHelper.Get<RequestDTO>(SD.StorageApiUrl + "Request/get_by_id?id=" + id);
            if (request != null)
            {
                return Ok(request);
            }

            return StatusCode(StatusCodes.Status404NotFound, "Can't not found with id: " + id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RequestApiModel<RequestModel> request)
        {
            var response = await HttpRequestsHelper.Post<Request>(SD.StorageApiUrl + "Request/create", request);
            if (response != null)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error when create request");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] RequestModel updatedRequest)
        {
            updatedRequest.RequestId = id;
            var response = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "Request/update", updatedRequest);
            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error when create request");
        }

        [HttpPost("{id}/update-status")]
        public async Task<IActionResult> UpdateStatusRequest(int id, [FromBody] UpdateStatusModel updateStatusModel)
        {
            updateStatusModel.RequestId = id;
            var response = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "Request/update/status", updateStatusModel);
            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error when create request");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var request = await HttpRequestsHelper.Delete<bool>(SD.StorageApiUrl + "Request/delete?id=" + id, id);
            if (request != false)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "failded when delete request id: " + id);
        }
    }
}
