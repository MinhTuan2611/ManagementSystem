using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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
        public async Task<TPagination<ProductListResponse>> Get(string? searchValue,int? categoryId, int pageSize = 0, int pageNumber = 0)
        {
            var (products,total) = await _ProductService.GetListProduct(searchValue, categoryId, pageSize, pageNumber);
            var result = new TPagination<ProductListResponse>();
            result.TotalItems = total;
            result.Items = products;
            return result;
        }
        [HttpGet("get-detail")]
        public ProductCreateUpdate GetDetailProduct(int productId)
        {
            var product = _ProductService.GetProductDetail(productId);
            return product;
        }

        [HttpGet("autocomplete-product")]
        public IActionResult AutoCompleteProduct(string? searchValue)
        {
            var products = _ProductService.AutoCompleteProduct(searchValue);
            if (products != null)
            {
                var lsProducts = products as List<ProductInfo> ?? products.ToList();
                if (lsProducts.Any())
                    return Ok(lsProducts);
            }
            return Ok(new List<ProductInfo>());
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

        [HttpGet("autocomplete-get-product-detail-for-sale")]
        public IActionResult AutocompleteGetProductDetailForSale(string barcode)
        {
            List<ProductDetailInSale>? product = _ProductService.AutoCompleteGetProductDetailForSale(barcode);
            return Ok(product);
        }

        [HttpGet()]
        [Route("auto-generate-product-code")]
        public IActionResult GenerateProductCode([FromQuery] int categoryId, [FromQuery] string productName )
        {
            string generateCode = _ProductService.GenerateProductCode(categoryId, productName);

            if (generateCode.Contains("can not be found."))
                return StatusCode(StatusCodes.Status500InternalServerError, generateCode);

            return Ok(generateCode);
        }

        [HttpGet()]
        [Route("random-selected-products")]
        public IActionResult GenerateProductCode([FromQuery] int items, [FromQuery] int? brandId)
        {
            var result = _ProductService.AutoRandomProducts(items, brandId);

            return Ok(result);
        }
    }
}
