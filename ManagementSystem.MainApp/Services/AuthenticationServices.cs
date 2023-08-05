using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.MainApp.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public IConfiguration _configuration;
        public AuthenticationServices(IConfiguration config)
        {
            _configuration = config;
        }
        public async Task<string> GenerateToken(Login user)
        {
            if (user != null && user.Password != null)
            {
                User userInfo = await GetUserLogin(user);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userInfo.UserId.ToString()),
                        new Claim("DisplayName", userInfo.FirstName + userInfo.LastName),
                        new Claim("UserName", userInfo.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Issuer"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(120),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<User> GetUserLogin(Login user)
        {
            using var httpClient = new HttpClient();
            var resLogin = await httpClient.PostAsJsonAsync(Environment.AccountApiUrl + "users/get-login", user);
            if (resLogin.IsSuccessStatusCode)
            {
                var content = await resLogin.Content.ReadAsStringAsync();
                var resultToken = JsonConvert.DeserializeObject<User>(content);
                return resultToken;
            }
            return null;
        }
    }
}
