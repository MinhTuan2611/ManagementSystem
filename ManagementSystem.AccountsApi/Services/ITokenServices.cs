using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountsApi.Services
{
    public interface ITokenServices
    {
        string GetToken(Login User);
    }
}
