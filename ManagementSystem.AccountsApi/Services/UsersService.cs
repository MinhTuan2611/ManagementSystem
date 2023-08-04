using ManagementSystem.AccountsApi.Models;
using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Models;
using ManagementSystem.EmployeesApi.Data;
using ManagementSystem.EmployeesApi.Data.Entities;

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
