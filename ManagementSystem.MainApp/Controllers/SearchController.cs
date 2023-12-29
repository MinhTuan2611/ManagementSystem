using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
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
    public class SearchController : ControllerBase
    {
        [HttpGet("Search")]
        public async Task<IActionResult> Get([FromQuery] string? searchValue, int branchId = 3)
        {
            MultipleSearchResult response = new MultipleSearchResult();
            List<CustomerResponseDto> customers = new List<CustomerResponseDto>();
            customers = await HttpRequestsHelper.GetList<CustomerResponseDto>(Environment.StorageApiUrl + "customers/search-term?searchTerm=" + searchValue);
            List<ProductDetailInSale> products = new List<ProductDetailInSale>();
            products = await HttpRequestsHelper.Get<List<ProductDetailInSale>>(Environment.StorageApiUrl + "products/" + "autocomplete-get-product-detail-for-sale?barcode=" + searchValue + "&branchId=" + branchId);
            response.CustomerResponses = customers;
            response.ProductResponses = products.Take(20).ToList();
            return Ok(response);
        }
    }
}
