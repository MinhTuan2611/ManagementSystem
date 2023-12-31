﻿using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private string APIUrl = Environment.StorageApiUrl + "products/";
        [HttpGet("get")]
        public async Task<IActionResult> Get(string? searchValue, int? categoryId, int pageSize = 0, int pageNumber = 0)
        {

            ResponsePagingModel<TPagination<ProductListResponse>> response = new ResponsePagingModel<TPagination<ProductListResponse>>();
            TPagination<ProductListResponse> products = await HttpRequestsHelper.Get<TPagination<ProductListResponse>>(APIUrl + "get?searchValue="+searchValue+ "&categoryId="+categoryId + "&pageSize=" + pageSize + "&pageNumber=" + pageNumber);
            if (products != null)
            {

                response.Status = "success";
                response.Data = products;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail(int? productId)
        {

            ResponseModel<ProductCreateUpdate> response = new ResponseModel<ProductCreateUpdate>();
            ProductCreateUpdate detail = await HttpRequestsHelper.Get<ProductCreateUpdate>(APIUrl + "get-detail?productId=" + productId );
            List<ProductCreateUpdate> responseData = new List<ProductCreateUpdate>();
            responseData.Add(detail);
            if (detail != null)
            {

                response.Status = "success";
                response.Data = responseData;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductCreateUpdate request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.ModifyBy = int.Parse(userId);

            bool isCreated = await HttpRequestsHelper.Post<bool>(APIUrl + "create", request);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpGet("autocomplete-product")]
        public async Task<IActionResult> AutoCompleteStorages(string? searchValue)
        {

           ResponseModel<ProductInfo> response = new ResponseModel<ProductInfo>();
           List<ProductInfo> lsProduct = await HttpRequestsHelper.Get<List<ProductInfo>>(APIUrl + "autocomplete-product?searchValue=" + searchValue);
            if (lsProduct != null)
            {

                response.Status = "success";
                response.Data = lsProduct;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ProductCreateUpdate request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.ModifyBy = Convert.ToInt32(userId);
            bool successfully = await HttpRequestsHelper.Post<bool>(APIUrl + "update", request);
            return Ok(successfully);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            bool successfully = await HttpRequestsHelper.Delete<bool>(APIUrl + "delete?productId="+ productId + "&userId="+ userId, new{ });
            return Ok(successfully);
        }
        [HttpGet("get-product-detail-for-sale")]
        public async Task<IActionResult> GetProductDetailForSale(string barcode, int branchId = 3)
        {
            ProductDetailInSale? product = await HttpRequestsHelper.Get<ProductDetailInSale>(APIUrl + "get-product-detail-for-sale?barcode=" + barcode + "&branchId=" + branchId);
            return Ok(product);
        }

        [HttpGet("autocomplete-get-product-detail-for-sale")]
        public async Task<IActionResult> AutocompleteGetProductDetailForSale(string barcode, int branchId = 3)
        {
            List<ProductDetailInSale>? product = await HttpRequestsHelper.Get<List<ProductDetailInSale>>(APIUrl + "autocomplete-get-product-detail-for-sale?barcode=" + barcode + "&branchId=" + branchId);
            return Ok(product);
        }

        [HttpGet()]
        [Route("auto-generate-product-code")]
        public async Task<IActionResult> AutoGenerateProductCode([FromQuery] int categoryId, [FromQuery] string productName)
        {
            var response = await HttpRequestsHelper.Get<string>(APIUrl + 
                    string.Format("auto-generate-product-code?categoryId={0}&productName={1}", categoryId, productName));
            
            if (string.IsNullOrEmpty(response))
                return BadRequest("Can not generate Code because invalid category id or productname can not be found");
            return Ok(response);
        }

        [HttpGet()]
        [Route("random-selected-products")]
        public async Task<IActionResult> AutoSelectedProducts([FromQuery] int items, [FromQuery] int? brandId)
        {
            ResponseModel<ProductAutoGenerationResponseDto> response = new ResponseModel<ProductAutoGenerationResponseDto>();
            var result = await HttpRequestsHelper.Get<List<ProductAutoGenerationResponseDto>>(APIUrl +
                    string.Format("random-selected-products?items={0}&productName={1}", items, brandId));
            
            if (result != null)
            {

                response.Status = "success";
                response.Data = result;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
