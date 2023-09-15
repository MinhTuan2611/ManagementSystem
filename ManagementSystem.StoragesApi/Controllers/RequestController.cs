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
        private readonly IRequestService _requestService;

        public RequestController(StoragesDbContext context)
        {
            _requestService = new RequestService(context);
        }

        [HttpGet("get")]
        public ActionResult<IEnumerable<RequestInfo>> GetListRequests()
        {
            var requests = _requestService.GetListRequests();
            return Ok(requests);
        }

        [HttpGet("get/{id}")]
        public ActionResult<RequestModel> GetRequestById(int id)
        {
            var request = _requestService.GetRequestById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        [HttpPost("create")]
        public ActionResult<Request> CreateRequest(RequestApiModel<RequestModel> request)
        {
            var createdRequest = _requestService.CreateRequest(request.Item, request.UserId);
            return Ok(createdRequest);
        }

        [HttpPost("update")]
        public ActionResult<bool> UpdateRequest(RequestApiModel<RequestModel> updatedRequest)
        {
            var result = _requestService.UpdateRequest(updatedRequest.Id, updatedRequest.Item, updatedRequest.UserId);
            return Ok(result);
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