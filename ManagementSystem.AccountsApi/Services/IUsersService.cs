using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Users;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IUsersService
    {
        //User GetUserById(int UserId);
        IEnumerable<UserInfo> GetAllUsers(string? searchValue);
        User GetUserLogin(Login userLogin);
        UserInfo GetUserByUsername(string? username);
        int CreateUser(UserRegister userEntity);
        bool UpdateUser(int UserId, UserInformation UserEntity);
        //bool DeleteUser(int UserId);
        string GetUserRoles(int UserId);
        List<UserRole> GetUserRoleDetail(int UserId);
        Task<ResponseDto> ChangePassword(UserChangePasswordRequestDto requestDto);
    }
}
