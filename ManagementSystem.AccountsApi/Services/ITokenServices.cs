using ManagementSystem.AccountsApi.Models;
using ManagementSystem.EmployeesApi.Data.Entities;

namespace ManagementSystem.AccountsApi.Services
{
    public interface ITokenServices
    {
        string GetToken(UserAPIModel User);
    }
}
