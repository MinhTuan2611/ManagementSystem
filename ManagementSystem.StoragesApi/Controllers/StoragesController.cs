using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IStoragesService _StoragesService;

        public StoragesController(StoragesDbContext context)
        {
            _StoragesService = new StoragesService(context);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var storages = _StoragesService.GetListStorages();
            if (storages != null)
            {
                var lsStorages = storages as List<Storage> ?? storages.ToList();
                if (lsStorages.Any())
                    return Ok(lsStorages);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        [HttpPost("create")]
        public IActionResult Create(Storage storage)
        {
            var newStorage = _StoragesService.CreateStorage(storage);
            if (newStorage != null)
            {
                return Ok(newStorage);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateStorageModel storage)
        {
            bool updated = _StoragesService.UpdateStorage(storage.StorageId, storage.Storage, storage.UserId);
            return Ok(updated);
        }

        [HttpPost("delete")]
        public IActionResult Delete(StorageRequest request)
        {
            bool updated = _StoragesService.DeleteStorage(request.StorageId, request.UserId);
            return Ok(updated);
        }
    }
}
