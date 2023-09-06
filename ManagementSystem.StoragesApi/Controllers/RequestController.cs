using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Services;

namespace ManagementSystem.StoragesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetListRequests()
        {
            var requests = _requestService.GetListRequests();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public ActionResult<Request> GetRequestById(int id)
        {
            var request = _requestService.GetRequestById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        [HttpPost]
        public ActionResult<Request> CreateRequest(Request request)
        {
            var createdRequest = _requestService.CreateRequest(request);
            return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.RequestId }, createdRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRequest(int id, Request updatedRequest)
        {
            var result = _requestService.UpdateRequest(id, updatedRequest);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(int id)
        {
            var result = _requestService.DeleteRequest(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}