using ManagementSystem.Common.Entities;
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
            if (categories != null)
            {
                var lsCategory = categories as List<Category> ?? categories.ToList();
                if (lsCategory.Any())
                    return Ok(lsCategory);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Categories not found");
        }
        [HttpPost("create")]
        public IActionResult Create(Category category)
        {
            var newUnit = _CategoriesService.CreateCategory(category);
            if (newUnit != null)
            {
                return Ok(newUnit);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(Category category, int userId)
        {
            bool updated = _CategoriesService.UpdateCategory(category, userId);
            return Ok(updated);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int unitId, int userId)
        {
            bool updated = _CategoriesService.DeleteCategory(unitId, userId);
            return Ok(updated);
        }
    }
}
