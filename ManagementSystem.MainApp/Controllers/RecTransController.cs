using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecTransController : ControllerBase
    {
        private string recTransUrl = Environment.AccountingApiUrl + "rectrans/";
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {

            LsRecTransRes response = new LsRecTransRes();
            List<RecTransInfoResponseDto> lsRecTrans = await HttpRequestsHelper.Get<List<RecTransInfoResponseDto>>(recTransUrl + "get");
            if (lsRecTrans != null)
            {

                response.Status = "success";
                response.RecTrans = lsRecTrans;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RecTransInfo payload)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            ResTransModel recTransPayload = new ResTransModel
            {
                UserId = userId,
                RecTrans = payload
            };
            bool newRecTrans = await HttpRequestsHelper.Post<bool>(recTransUrl + "create", recTransPayload);
            if (newRecTrans)
            {
                return Ok(newRecTrans);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ResTransModel updateStorage)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            updateStorage.UserId = Convert.ToInt32(userId);
            bool successfully = await HttpRequestsHelper.Post<bool>(recTransUrl + "update", updateStorage);
            return Ok(successfully);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int storageId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            StorageRequest request = new StorageRequest
            {
                UserId = userId,
                StorageId = storageId
            };

            bool successfully = await HttpRequestsHelper.Post<bool>(recTransUrl + "delete", request);
            return Ok(successfully);
        }
    }
}
