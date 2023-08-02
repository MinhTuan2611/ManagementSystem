using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
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
    }
}
