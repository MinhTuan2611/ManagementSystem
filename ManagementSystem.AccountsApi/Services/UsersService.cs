﻿using ManagementSystem.AccountsApi.Models;
using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.EmployeesApi.Data;

namespace ManagementSystem.AccountsApi.Services
{
    public class UsersService : IUsersService
    {
        private readonly UnitOfWork _unitOfWork;

        public UsersService(AccountsDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<UserInfo> GetAllUsers(string? searchValue)
        {
            List<User> users;
            if (searchValue == null)
            {
                users = _unitOfWork.UserRepository.GetAll().ToList();
            } else
            {
                users = _unitOfWork.UserRepository.GetMany(u=> u.UserName.Contains(searchValue)
                || u.FirstName.Contains(searchValue) 
                || u.LastName.Contains(searchValue) 
                || (u.Email != null && u.Email.Contains(searchValue))
                || (u.PhoneNumber != null && u.PhoneNumber.Contains(searchValue))).ToList();
            }
            var usersRes = new List<UserInfo>();
            if (users.Any())
                foreach (var user in users)
                {
                    var roles = "";
                    List<int> roleIds = _unitOfWork.UserRoleRepository.GetMany(x => x.UserId == user.UserId).Select(x => x.RoleId).ToList();
                    if (roleIds != null)
                    {
                        roles = string.Join(",", roleIds);
                    }
                    usersRes.Add(new UserInfo
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FullName = user.FirstName + " " + user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        RoleIds = roles
                    });
                };
                return usersRes;
            return null;
        }

        public User GetUserLogin(Login userLogin)
        {
            var users = _unitOfWork.UserRepository.Get(u => u.UserName == userLogin.UserName && BCrypt.Net.BCrypt.Verify(userLogin.Password, u.Password));
            return users;
        }

        public UserInfo GetUserByUsername(string username)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == username);
            UserInfo userInfo = new UserInfo
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return userInfo;
        }

        public int CreateUser(UserRegister userEntity)
        {
            try
            {
                User userInfo = _unitOfWork.UserRepository.Get(u => u.UserName == userEntity.UserName);
                if (userInfo != null)
                {
                    return -2;
                }
                User newUser = new User
                {
                    UserName = userEntity.UserName,
                    Password = userEntity.Password,
                    LastName = userEntity.LastName,
                    FirstName = userEntity.FirstName,
                    Email = userEntity.Email,
                    PhoneNumber = userEntity.PhoneNumber,
                };
                _unitOfWork.UserRepository.Insert(newUser);
                _unitOfWork.Save();
                User user = _unitOfWork.UserRepository.Get(u => u.UserName == userEntity.UserName);
                if (user != null)
                {
                    if (userEntity.Roles != null)
                    {
                        List<int> roleIds = userEntity.Roles.Split(',').Select(Int32.Parse).ToList();
                        foreach (var roleId in roleIds)
                        {
                            var role = _unitOfWork.RoleRepository.GetByID(roleId);
                            var userRole = new UserRole
                            {
                                user = user,
                                role = role
                            };
                            _unitOfWork.UserRoleRepository.Insert(userRole);
                        }
                        _unitOfWork.Save();
                    }
                    return user.UserId;
                } else { return -1; }

            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public bool UpdateUser(int UserId, UserInformation UserEntity)
        {
            if (UserId < 1 || UserEntity == null)
            {
                return false;
            }

            User user = _unitOfWork.UserRepository.GetFirst(u => u.UserId == UserId);
            if (user != null)
            {
                user.FirstName = UserEntity.FirstName; 
                user.LastName = UserEntity.LastName;
                user.Email = UserEntity.Email;
                user.PhoneNumber = UserEntity.PhoneNumber;

                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Save();
                if (UserEntity.Roles != null)
                {
                    List<int> roleIds = UserEntity.Roles.Split(',').Select(Int32.Parse).ToList();
                    _unitOfWork.UserRoleRepository.Delete(x => x.UserId == user.UserId);
                    foreach (var roleId in roleIds)
                    {
                        var role = _unitOfWork.RoleRepository.GetByID(roleId);
                        var userRole = new UserRole
                        {
                            user = user,
                            role = role
                        };
                        _unitOfWork.UserRoleRepository.Insert(userRole);
                    }
                    _unitOfWork.Save();
                }
                return true;
            }
            return false;

        }
        public string GetUserRoles(int userId)
        {
            var roles = "";
            List<int> roleIds = _unitOfWork.UserRoleRepository.GetMany(x => x.UserId == userId).Select(x => x.RoleId).ToList();
            if (roleIds != null)
            {
                roles = string.Join(",", roleIds);
            }
            return roles;
        }
    }
}
