using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicBillController : ControllerBase
    {
        private IElectronicService _service;

        public ElectronicBillController(IElectronicService electronicService)
        {
            _service = electronicService;
        }

        [HttpGet("get_lastest_electronic_pattern")]
        public async Task<IActionResult> GetLastestElectronicParttern()
        {
            return Ok(await _service.GetLastestPattern());
        }
    }

}
