using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLoggingController : ControllerBase
    {
        private readonly IEventloggingService _service;

        public EventLoggingController(IEventloggingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventLoggingRequestDto requestDtoq)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            requestDtoq.UserId = int.Parse(userId);

            var result = await _service.Create(requestDtoq);

            if (result.IsSuccess)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}
