using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfAccountingsController : ControllerBase
    {
        private readonly ITypesOfAccountsService _TypesOfAccountsService;
        public TypeOfAccountingsController(AccountingDbContext context)
        {
            _TypesOfAccountsService = new TypesOfAccountsService(context);
        }

        // GET api/user/get
        [HttpGet("get")]
        public IActionResult Get(string? searchValue)
        {
            var types = _TypesOfAccountsService.GetAll();
            if (types != null)
            {
                var lsLypesOfAccounts = types as List<TypesOfAccounts> ?? types.ToList();
                if (lsLypesOfAccounts.Any())
                    return Ok(lsLypesOfAccounts);
            }
            return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }
    }
}
