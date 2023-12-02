using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;

namespace ManagementSystem.StoragesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;

        public RequestController(StoragesDbContext context)
        {
            _requestService = new RequestService(context);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Request>> GetListRequests()
        {
            var requests = _requestService.GetListRequests();
            return Ok(requests);
        }

        [HttpGet("get_by_id")]
        public ActionResult<Request> GetRequestById([FromQuery]int id)
        {
            var request = _requestService.GetRequestById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        [HttpPost("create")]
        public ActionResult<Request> CreateRequest([FromBody] RequestApiModel<RequestModel> request)
        {
            var createdRequest = _requestService.CreateRequest(request.Item);
            return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.RequestId }, createdRequest);
        }

        [HttpPost("update")]
        public IActionResult UpdateRequest([FromBody] Request updatedRequest)
        {
            int id = updatedRequest.RequestId;
            var result = _requestService.UpdateRequest(id, updatedRequest);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteRequest([FromQuery]int id)
        {
            var result = _requestService.DeleteRequest(id);
            return Ok(result);
        }
    }
}