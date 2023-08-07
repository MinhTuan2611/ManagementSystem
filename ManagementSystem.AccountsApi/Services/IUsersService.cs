using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IUsersService
    {
        //User GetUserById(int UserId);
        IEnumerable<User> GetAllUsers();
        User GetUserLogin(Login UserLogin);
        int CreateUser(UserRegister UserEntity);
        //bool UpdateUser(int UserId, User UserEntity);
        //bool DeleteUser(int UserId);
    }
}
