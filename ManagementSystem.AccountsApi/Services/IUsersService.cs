using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IUsersService
    {
        //User GetUserById(int UserId);
        IEnumerable<UserInfo> GetAllUsers();
        User GetUserLogin(Login userLogin);
        UserInfo GetUserByUsername(string username);
        int CreateUser(UserRegister userEntity);
        //bool UpdateUser(int UserId, User UserEntity);
        //bool DeleteUser(int UserId);
    }
}
