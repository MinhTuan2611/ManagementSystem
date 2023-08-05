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

        public int CreateUser(UserRegister UserEntity)
        {
            try
            {
                User newUser = new User
                {
                    UserName = UserEntity.UserName,
                    Password = UserEntity.Password,
                    LastName = UserEntity.LastName,
                    FirstName = UserEntity.FirstName,
                    Email = UserEntity.Email,
                    PhoneNumber = UserEntity.PhoneNumber,
                };
                _unitOfWork.UserRepository.Insert(newUser);
                _unitOfWork.Save();
                User user = _unitOfWork.UserRepository.Get(u => u.UserName == UserEntity.UserName);
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
