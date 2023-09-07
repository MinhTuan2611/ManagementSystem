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
    public class StoragesController : ControllerBase
    {
        private string storageUrl = Environment.StorageApiUrl + "storages/";

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {

            LsStorageRes response = new LsStorageRes();
            List<Storage> lsStorages = await HttpRequestsHelper.Get<List<Storage>>(storageUrl + "get");
            if (lsStorages != null)
            {

                response.Status = "success";
                response.Storages = lsStorages;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpGet("autocomplete-storages")]
        public async Task<IActionResult> AutoCompleteStorages(string? searchValue)
        {

            ResponseModel<Storage> response = new ResponseModel<Storage>();
            List<Storage> lsStorages = await HttpRequestsHelper.Get<List<Storage>>(storageUrl + "autocomplete-storages?searchValue=" + searchValue);
            if (lsStorages != null)
            {

                response.Status = "success";
                response.Data = lsStorages;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(StorageInfo storage)
        {
            Storage storagePayload = new Storage
            {
                StorageCode = storage.StorageCode,
                StorageName = storage.StorageName,
                Address = storage.Address,
                Phone = storage.Phone,
                BranchId = storage.BranchId
            };
            Storage newBranch = await HttpRequestsHelper.Post<Storage>(storageUrl + "create", storagePayload);
            if (newBranch != null)
            {
                return Ok(newBranch);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateStorageModel updateStorage)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            updateStorage.UserId = Convert.ToInt32(userId);
            bool successfully = await HttpRequestsHelper.Post<bool>(storageUrl + "update", updateStorage);
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

            bool successfully = await HttpRequestsHelper.Post<bool>(storageUrl + "delete", request);
            return Ok(successfully);
        }
    }
}
