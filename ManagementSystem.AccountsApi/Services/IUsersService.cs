using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Models;
using ManagementSystem.EmployeesApi.Data.Entities;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IUsersService
    {
        //User GetUserById(int UserId);
        IEnumerable<User> GetAllUsers();
        int CreateUser(UserRegister UserEntity);
        //bool UpdateUser(int UserId, User UserEntity);
        //bool DeleteUser(int UserId);
    }
}
