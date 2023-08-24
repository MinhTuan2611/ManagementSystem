using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;

namespace ManagementSystem.AccountingApi.Services
{
    public class TypesOfAccountsService : ITypesOfAccountsService
    {
        private readonly UnitOfWork _unitOfWork;

        public TypesOfAccountsService(AccountingDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<TypesOfAccounts> GetAll()
        {
            List<TypesOfAccounts> typesOfAccounts = _unitOfWork.TypesOfAccountsRepository.GetAll().ToList();
            if (typesOfAccounts.Any())
            {
                return typesOfAccounts;
            }
            return null;
        }
    }
}
