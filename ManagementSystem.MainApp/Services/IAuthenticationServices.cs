using ManagementSystem.Common.Models;

namespace ManagementSystem.MainApp.Services
{
    public interface IAuthenticationServices
    {
        Task<string> GenerateToken(Login user);
    }
}
