﻿using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentGroupsController : ControllerBase
    {
        private string APIUrl = SD.AccountingApiUrl + "DocumentGroups/";


        [HttpPost("search_results")]
        public async Task<IActionResult> SearchInventory([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<LegerResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }
    }
}
