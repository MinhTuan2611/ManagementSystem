﻿using ManagementSystem.Common.Entities;
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
        public async Task<IActionResult> Get([FromQuery] string? searchValue)
        {
            MultipleSearchResult response = new MultipleSearchResult();
            List<CustomerResponseDto> customers = new List<CustomerResponseDto>();
            customers = await HttpRequestsHelper.GetList<CustomerResponseDto>(Environment.StorageApiUrl + "customers/search-term?searchTerm=" + searchValue);
            TPagination<ProductListResponse> products = new TPagination<ProductListResponse>();
            products = await HttpRequestsHelper.Get<TPagination<ProductListResponse>>(Environment.StorageApiUrl + "products/" + "get?searchValue=" + searchValue + "&pageNumber=1&pageSize=9");
            response.CustomerResponses = customers;
            response.ProductResponses = products.Items;
            return Ok(response);
        }
    }
}
