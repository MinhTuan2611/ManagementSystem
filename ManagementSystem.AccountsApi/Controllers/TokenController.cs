using ManagementSystem.AccountsApi.Models;
using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data;
using ManagementSystem.EmployeesApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.AccountsApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenServices _TokenService;
        public TokenController(IConfiguration config, AccountsDbContext context)
        {
            _TokenService = new TokenServices(config, context);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserAPIModel _userData)
        {
            if (_userData != null && _userData.Password != null)
            {
                string token = _TokenService.GetToken(_userData);

                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
