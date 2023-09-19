using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.RequestSamples;
using ManagementSystem.MainApp.CustomerActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestSampleController : ControllerBase
    {
        private string APIUrl = Environment.StorageApiUrl + "RequestSample/";


        [HttpGet("get-request-samples")]
        public async Task<IActionResult> Get()
        {
            var  samples = await HttpRequestsHelper.GetList<ResponseSampleDto>(APIUrl + "get-samples");
            if (samples != null)
            {
                return Ok(samples);
            }
            return Ok("The sample is empty");

        }

        [HttpGet("get-request-sample")]
        public async Task<IActionResult> GetSample([FromQuery] int sampleId)
        {
            var sample = await HttpRequestsHelper.Get<ResponseSampleDto>(APIUrl + "get-sample?sampleId=" + sampleId);
            if (sample != null)
            {
                return Ok(sample);
            }
            return Ok("The sample can not found");

        }

        [HttpPost("create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] NewRequestSampleDto request)
        {
            if (request == null)
                return BadRequest("Request Data is empty.");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            bool isCreated = await HttpRequestsHelper.Post<bool>(APIUrl + "create", request);
            if (isCreated)
            {
                return Ok(isCreated);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRequestSampleDto request)
        {
            if (request == null)
                return BadRequest("Request Data is empty.");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            bool successfully = await HttpRequestsHelper.Post<bool>(APIUrl + "update", request);
            return Ok(successfully);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int requestId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            bool successfully = await HttpRequestsHelper.Delete<bool>(APIUrl + "delete?requestId=" + requestId + "&userId=" + userId, new { });
            return Ok(successfully);
        }
    }
}
