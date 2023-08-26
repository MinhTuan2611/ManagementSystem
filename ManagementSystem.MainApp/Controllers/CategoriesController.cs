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
    public class CategoriesController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await HttpRequestsHelper.Get<List<Category>>(Environment.StorageApiUrl + "categories/get");
            if (categories != null || categories.Count > 0)
            {
                return Ok(categories);
            }
            return Ok("Categories not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Category category)
        {
            var newCategory = await HttpRequestsHelper.Post<Category>(Environment.StorageApiUrl + "categories/create", category);
            if (newCategory != null) 
            {
                return Ok(newCategory);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            bool updated = await HttpRequestsHelper.Post<bool>(Environment.AccountApiUrl + "categories/update", request);
            return Ok(updated);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            bool updated = await HttpRequestsHelper.Delete<bool>(Environment.AccountApiUrl + "categories/update", categoryId);
            return Ok(updated);
        }
    }
}
