using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecTransController : ControllerBase
    {
        private readonly IRecordingtransactionsService _RecordingtransactionsService;
        public RecTransController(AccountingDbContext context)
        {
            _RecordingtransactionsService = new RecordingtransactionsService(context);
        }

        // GET api/recTrans/get
        [HttpGet("get")]
        public IActionResult Get(string? searchValue)
        {
            var records = _RecordingtransactionsService.GetAll();
            if (records != null)
            {
                var lsRecords = records as List<RecTransInfo> ?? records.ToList();
                if (lsRecords.Any())
                    return Ok(lsRecords);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Information not found");
        }

        [HttpPost("create")]
        public IActionResult Create(ResTransModel requestValue)
        {
            bool success = _RecordingtransactionsService.CreateRecordTrans(requestValue.RecTrans, requestValue.UserId);
            return Ok(success);
        }

        [HttpPost("edit")]
        public IActionResult Edit(ResTransModel requestValue)
        {
            bool success = _RecordingtransactionsService.EditRecordTrans(requestValue.RecTransId ?? 0, requestValue.RecTrans, requestValue.UserId);
            return Ok(success);
        }

        [HttpPost("delete")]
        public IActionResult Delete(RecTransRequest requestValue)
        {
            bool success = _RecordingtransactionsService.DeleteRecordTrans(requestValue.RecTransId ?? 0, requestValue.UserId);
            return Ok(success);
        }
    }
}
