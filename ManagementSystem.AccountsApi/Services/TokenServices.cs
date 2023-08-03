using ManagementSystem.AccountsApi.Models;
using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Helpers;
using ManagementSystem.EmployeesApi.Data;
using ManagementSystem.EmployeesApi.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.AccountsApi.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly UnitOfWork _unitOfWork;
        public IConfiguration _configuration;
        public TokenServices(IConfiguration config, AccountsDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _configuration = config;
        }
        public string GetToken(UserAPIModel User)
        {
            if (User != null && User.Password != null)
            {
                var user = _unitOfWork.UserRepository.Get(u => u.UserName == User.UserName && BCrypt.Net.BCrypt.Verify(User.Password,u.Password));

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.FirstName + user.LastName),
                        new Claim("UserName", user.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                } else
                {
                    return null;
                }
            } else
            {
                return null;
            }
        }
    }
}
