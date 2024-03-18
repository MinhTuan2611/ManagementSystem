using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponsePagingModel<ResponseTransferDto> response = new ResponsePagingModel<ResponseTransferDto>();
            var transfers = await HttpRequestsHelper.Get<ResponseTransferDto>(SD.StorageApiUrl + "TransferStorege");
            if (transfers != null)
            {

                response.Status = "success";
                response.Data = transfers;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("get_by_id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var transfer = await HttpRequestsHelper.Get<TransferDTO>(SD.StorageApiUrl + "TransferStorege/get_by_id?id=" + id);
            if (transfer != null)
            {
                return Ok(transfer);
            }

            return StatusCode(StatusCodes.Status404NotFound, "Can't not found with id: " + id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TransferApiModel<TransferModel> transfer)
        {
            var response = await HttpRequestsHelper.Post<Transfer>(SD.StorageApiUrl + "TransferStorege/create", transfer);
            if (response != null)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error when create request");
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> update(int id, [FromBody] TransferModel updatedTransfer)
        {
            updatedTransfer.TransferId = id;
            var response = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "TransferStorege/update", updatedTransfer);
            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error when update transfer");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var request = await HttpRequestsHelper.Delete<bool>(SD.StorageApiUrl + "TransferStorege/delete?id=" + id, id);
            if (request != false)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "failded when delete transfer id: " + id);
        }
    }
}
