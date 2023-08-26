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
    }
}
