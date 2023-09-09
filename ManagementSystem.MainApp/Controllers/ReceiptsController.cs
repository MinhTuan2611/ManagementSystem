using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private string APIUrl = Environment.StorageApiUrl + "request/";

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            ResponseModel<RequestInfo> response = new ResponseModel<RequestInfo>();
            List<RequestInfo> lsRceipts = await HttpRequestsHelper.Get<List<RequestInfo>>(APIUrl + "get");
            if (lsRceipts != null)
            {

                response.Status = "success";
                response.Data = lsRceipts;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetReceiptById(int id)
        {
            RequestModel receipt = await HttpRequestsHelper.Get<RequestModel>(APIUrl + "get/" + id);
            if (receipt != null)
            {
                return Ok(receipt);
            }
            return Ok(null);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RequestModel request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            RequestApiModel<RequestModel> payload = new RequestApiModel<RequestModel>();
            payload.Item = request;
            payload.UserId = Convert.ToInt32(userId);
            Request isCreated = await HttpRequestsHelper.Post<Request>(APIUrl + "create", payload);
            if (isCreated != null)
            {
                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }
}
