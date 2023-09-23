using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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
        private readonly IMapper _mapper;

        public RequestSampleController(StoragesDbContext context, IMapper mapper)
        {
            _RequestSampleService = new RequestSampleService(context);
            _mapper = mapper;
        }

        [HttpGet("get-samples")]
        public IActionResult Get()
        {
            var requests = _RequestSampleService.GetListRequestSamples();
            if (requests != null)
            {
                return Ok(requests);

            }
            return StatusCode(StatusCodes.Status404NotFound, "404 not found");
        }

        [HttpGet("get-sample")]
        public IActionResult GetBySampleId([FromQuery]int sampleId)
        {
            var requests = _RequestSampleService.GetRequestSampleById(sampleId);
            if (requests != null)
            {
                return Ok(requests);

            }
            return StatusCode(StatusCodes.Status404NotFound, "404 not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NewRequestSampleDto requests)
        {
            var requestSample = _mapper.Map<RequestSample>(requests);

            // Add Metadata
            requestSample.CreateBy = requests.UserId;
            requestSample.ModifyBy = requests.UserId;
            requestSample.UserId = requests.UserId;

            var newrequests = await _RequestSampleService.CreateRequestSample(requestSample);
            if (newrequests != null)
            {
                return Ok(true);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRequestSampleDto requests)
        {
            var requestSample = _mapper.Map<RequestSample>(requests);

            // Add Metadata
            requestSample.CreateBy = requests.UserId;
            requestSample.ModifyBy = requests.UserId;
            requestSample.UserId = requests.UserId;

            bool updated = await _RequestSampleService.UpdateRequestSample(requestSample);
            return Ok(updated);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int requestId, [FromQuery] int userId)
        {
            bool updated = await _RequestSampleService.DeleteRequestSample(requestId, userId);
            return Ok(updated);
        }
    }
}
