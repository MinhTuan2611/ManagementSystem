using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<Unit> units = await HttpRequestsHelper.Get<List<Unit>>(Environment.StorageApiUrl + "units/get");
            if (units != null || units.Count > 0)
            {
                return Ok(units);
            }
            return Ok("Units not found");
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Unit unit)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            unit.CreateBy = int.Parse(userId);
            var units = await HttpRequestsHelper.Post<Unit>(Environment.StorageApiUrl + "units/create", unit);
            if (units != null)
            {
                return Ok(units);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Unit unit)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            unit.ModifyBy = int.Parse(userId);
            var units = await HttpRequestsHelper.Post<Unit>(Environment.StorageApiUrl + "units/update", unit);
            if (units != null)
            {
                return Ok(units);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var units = await HttpRequestsHelper.Delete<bool>(Environment.StorageApiUrl + "units/"+ id, id);
            if (units)
            {
                return Ok(units);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
    }
}
