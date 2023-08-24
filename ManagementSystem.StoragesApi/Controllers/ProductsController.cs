using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _ProductService;

        public ProductsController(StoragesDbContext context)
        {
            _ProductService = new ProductsService(context);
        }
        [HttpGet("get")]
        public List<ProductListResponse> Get()
        {
            var products = _ProductService.GetListProduct();
            return products;
        }
        [HttpGet("get-detail")]
        public ProductCreateUpdate GetDetailProduct(int productId)
        {
            var product = _ProductService.GetProductDetail(productId);
            return product;
        }
        [HttpPost("create")]
        public IActionResult Create(ProductCreateUpdate request)
        {
            var newUnit = _ProductService.CreateProduct(request);
            if (newUnit == true)
            {
                return Ok(newUnit);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(ProductCreateUpdate request)
        {
            bool updated = _ProductService.UpdateProduct(request);
            return Ok(updated);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int productId)
        {
            bool deleted = _ProductService.DeleteProduct(productId);
            return Ok(deleted);
        }
    }
}
