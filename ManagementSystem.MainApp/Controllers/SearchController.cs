using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet("Search")]
        public async Task<IActionResult> Get([FromQuery] string? searchValue, int branchId = 3, int pageNumber = 1, int pageSize = 20)
        {
            MultipleSearchResult response = new MultipleSearchResult();
            List<CustomerResponseDto> customers = new List<CustomerResponseDto>();
            customers = await HttpRequestsHelper.GetList<CustomerResponseDto>(Environment.StorageApiUrl + "customers/search-term?searchTerm=" + searchValue);
            TPagination<ProductDetailInSale>? products = await HttpRequestsHelper.Get<TPagination<ProductDetailInSale>>(SD.StorageApiUrl + "Products/autocomplete-get-product-detail-for-sale?barcode=" + searchValue + "&branchId=" + branchId
                                                                                                                + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize);
            response.CustomerResponses = customers;
            response.ProductResponses = products.Items.ToList();
            return Ok(response);
        }
    }
}
