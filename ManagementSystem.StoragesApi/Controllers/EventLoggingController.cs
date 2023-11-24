using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLoggingController : ControllerBase
    {
        private readonly IEventLoggingService _service;
        public EventLoggingController(IEventLoggingService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ResponseDto> Create([FromBody] EventLoggingRequestDto requestDto)
        {
            var result = await _service.CreateEventLogAsync(requestDto);
            return result;
        }
    }
}
