﻿using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Models.Dtos.Accounting;
using ManagementSystem.Common.Entities;
using ManagementSystem.MainApp.Utility;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitVouchersController : ControllerBase
    {
        private string APIUrl = SD.AccountingApiUrl + "DebitVouchers/";

        [HttpPost("search_results")]
        public async Task<IActionResult> SearchInventory([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<DebitVoucherResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetDetail([FromQuery] int documentNumber)
        {

            ResponseModel<DebitVoucherResponseDto> response = new ResponseModel<DebitVoucherResponseDto>();
            DebitVoucherResponseDto detail = await HttpRequestsHelper.Get<DebitVoucherResponseDto>(APIUrl + "get_detail?documentNumber=" + documentNumber);
            List<DebitVoucherResponseDto> responseData = new List<DebitVoucherResponseDto>();
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
        public async Task<IActionResult> Create(NewDebitVoucherRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = int.Parse(userId);

            var result = await HttpRequestsHelper.Post<DebitVoucher>(APIUrl + "create", request);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateDebitVoucherRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request Data");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            request.UserId = Convert.ToInt32(userId);

            var result = await HttpRequestsHelper.Post<DebitVoucher>(APIUrl + "update", request);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status500InternalServerError, "System can not find the debit voucher or faild when update");
        }
    }
}
