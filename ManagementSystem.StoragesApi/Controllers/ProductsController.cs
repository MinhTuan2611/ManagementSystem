using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Products;
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

        public ProductsController(StoragesDbContext context, IConfiguration configuration)
        {
            _ProductService = new ProductsService(context, configuration);
        }
        [HttpGet("get")]
        public async Task<TPagination<ProductListResponse>> Get(string? searchValue, int? categoryId, int pageSize = 0, int pageNumber = 0)
        {
            var (products, total) = await _ProductService.GetListProduct(searchValue, categoryId, pageSize, pageNumber);
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
            var storages = _ProductService.AutoCompleteProduct(searchValue);
            if (storages != null)
            {
                var lsStorages = storages as List<ProductInfo> ?? storages.ToList();
                if (lsStorages.Any())
                    return Ok(lsStorages);
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
        public IActionResult GetProductDetailForSale(string barcode, int branchId)
        {
            ProductDetailInSale? product = _ProductService.GetProductDetailForSale(barcode, branchId);
            return Ok(product);
        }

        [HttpGet("autocomplete-get-product-detail-for-sale")]
        public IActionResult AutocompleteGetProductDetailForSale(string barcode, int branchId, int pageNumber, int pageSize)
        {
            TPagination<ProductDetailInSale>? product = _ProductService.AutoCompleteGetProductDetailForSale(barcode, pageNumber, pageSize, branchId);

            return Ok(product);
        }

        [HttpGet()]
        [Route("auto-generate-product-code")]
        public IActionResult GenerateProductCode([FromQuery] int categoryId, [FromQuery] string productName)
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

        [HttpPost()]
        [Route("review-import-products")]
        public IActionResult ReviewImportExcel(IFormFile file)
        {
            // Check if the uploaded file is not null and is an Excel file based on its content type
            if (file == null || !file.ContentType.Contains("excel") && !file.ContentType.Contains("spreadsheetml"))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid file. Please upload an Excel file.");
            }
            List<ProductReviewImportDto> result = _ProductService.ReviewImportProduct(file);
            if(result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fail reviewing the Excel file.");

            }
            return Ok(result);
        }

        [HttpGet()]
        [Route("get-detail-by-id-unitid")]
        public IActionResult GenerateProductCode([FromQuery] int productId, [FromQuery] int unitId)
        {
            var result = _ProductService.ProductDetailByIdAndUnit(productId, unitId);

            return Ok(result);
        }

        [HttpPost()]
        [Route("import-products")]
        public IActionResult ImportExcel(List<ProductImportRequest> importFile,int userId)
        {
            // Check if the uploaded file is not null and is an Excel file based on its content type
            if (importFile == null || !importFile.Any())
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No product to import");
            }
            var sucesss = _ProductService.ImportProduct(importFile, userId);
            if(sucesss == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fail importing the Excel file.");
            }
            return Ok();
        }
    }
}
