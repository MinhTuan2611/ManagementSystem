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
        public List<ProductListResponse> Get(string? searchValue,int? categoryId )
        {
            var products = _ProductService.GetListProduct(searchValue, categoryId);
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
            var isCreated = _ProductService.CreateProduct(request);
            if (isCreated == true)
            {
                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
        [HttpPost("update")]
        public IActionResult Update(ProductCreateUpdate request)
        {
            bool updated = _ProductService.UpdateProduct(request);
            return Ok(updated);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int productId, int? userId)
        {
            bool deleted = _ProductService.DeleteProduct(productId, userId);
            return Ok(deleted);
        }
        [HttpGet("get-product-detail-for-sale")]
        public IActionResult GetProductDetailForSale(string barcode)
        {
            ProductDetailInSale? product = _ProductService.GetProductDetailForSale(barcode);
            return Ok(product);
        }
    }
}
