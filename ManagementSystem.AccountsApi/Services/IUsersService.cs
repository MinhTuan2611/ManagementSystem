﻿using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

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
    }
}
