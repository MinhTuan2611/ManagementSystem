using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestSampleController : ControllerBase
    {
        private readonly IRequestSampleService _RequestSampleService;

        public RequestSampleController(StoragesDbContext context)
        {
            _RequestSampleService = new RequestSampleService(context);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var requests = _RequestSampleService.GetListRequestSamples();
            if (requests != null)
            {
                var ls = requests as List<RequestSample> ?? requests.ToList();
                if (ls.Any())
                    return Ok(ls);
            }
            return StatusCode(StatusCodes.Status404NotFound, "404 not found");
        }

        [HttpPost("create")]
        public IActionResult Create(RequestSample requests)
        {
            var newrequests = _RequestSampleService.CreateRequestSample(requests);
            if (newrequests != null)
            {
                return Ok(newrequests);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public IActionResult Update(RequestSampleModel request)
        {
            bool updated = _RequestSampleService.UpdateRequestSample(request.Id, request);
            return Ok(updated);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            bool updated = _RequestSampleService.DeleteRequestSample(id);
            return Ok(updated);
        }
    }
}
