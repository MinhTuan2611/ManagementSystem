using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfAccountsController : ControllerBase
    {
        private string recTransUrl = Environment.AccountingApiUrl + "TypeOfAccountings/";
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {

            LsTypeOfAccountingsRes response = new LsTypeOfAccountingsRes();
            List<TypesOfAccountsInfo> lsTypeOfAccounts = await HttpRequestsHelper.Get<List<TypesOfAccountsInfo>>(recTransUrl + "get");
            if (lsTypeOfAccounts != null)
            {

                response.Status = "success";
                response.Data = lsTypeOfAccounts;
                return Ok(response);
            }
            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }
    }
}
