using ManagementSystem.AccountsApi.Models;
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

        public IEnumerable<User> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            if (users.Any())
            
                return users;
            return null;
        }

        public User GetUserLogin(Login UserLogin)
        {
            var users = _unitOfWork.UserRepository.Get(u => u.UserName == UserLogin.UserName && BCrypt.Net.BCrypt.Verify(UserLogin.Password, u.Password));
            return users;
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
                    return user.UserId;
                } else { return -1; }
                
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
