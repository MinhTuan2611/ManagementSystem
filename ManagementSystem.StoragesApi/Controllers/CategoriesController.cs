using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _CategoriesService;

        public CategoriesController(StoragesDbContext context)
        {
            _CategoriesService = new CategoriesService(context);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var categories = _CategoriesService.GetListCategory();
            return Ok(categories);
        }
        [HttpPost("create")]
        public IActionResult Create(Category category)
        {
            var newCategory = _CategoriesService.CreateCategory(category);
            if (newCategory != null)
            {
                return Ok(newCategory);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(CategoryUpdateRequest request)
        {
            bool updated = _CategoriesService.UpdateCategory(request.category, request.userId);
            return Ok(updated);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int categoryId, int? userId)
        {
            bool updated = _CategoriesService.DeleteCategory(categoryId, userId);
            return Ok(updated);
        }
    }
}
