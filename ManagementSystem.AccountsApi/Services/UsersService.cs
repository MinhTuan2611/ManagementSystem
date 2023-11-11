using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.EmployeesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountsApi.Services
{
    public class UsersService : IUsersService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AccountsDbContext _context;

        public UsersService(AccountsDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _context = context;
        }

        public IEnumerable<UserInfo> GetAllUsers(string? searchValue)
        {
            List<User> users;
            if (searchValue == null)
            {
                users = _unitOfWork.UserRepository.GetAll().ToList();
            }
            else
            {
                users = _unitOfWork.UserRepository.GetMany(u => u.UserName.Contains(searchValue)
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
            string[] includes = { "role" };
            List<string> roleCodes = _unitOfWork.UserRoleRepository.GetWithInclude(x => x.UserId == user.UserId, includes).Select(x => x.role.RoleCode).ToList();
            UserInfo userInfo = new UserInfo
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleIds = string.Join(",", roleCodes)
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
                }
                else { return -1; }

            }
            catch (Exception ex)
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

                var userBrand = GetUserBranch(UserId);
                if (userBrand != null)
                {
                    UpdateUserBrand(UserId, UserEntity.BranchId.Value);
                }
                else
                {
                    var newUserBrand = new UserBranch()
                    {
                        BranchId = UserEntity.BranchId,
                        UserId = UserId
                    };

                    _context.UserBranchs.Add(newUserBrand);
                    _context.SaveChanges();
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

        #region Private handle methods
        private UserBrandDto GetUserBranch(int userId)
        {
            string query = string.Format(@"
                SELECT UserId
                        ,BranchId
                FROM dbo.UserBranchs
                WHERE UserId = {0}
            ", userId);

            try
            {
                var result = _context.UserBrandDtos.FromSqlRaw(query).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool UpdateUserBrand(int userId, int brandId)
        {
            string query = string.Format(@"
                UPDATE dbo.UserBranchs
                SET BranchId = {0}
                WHERE UserId = {1}
            ", brandId, userId);

            try
            {
                var result = _context.Database.ExecuteSqlRaw(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
