using ManagementSystem.Common.Entities;

namespace ManagementSystem.AccountingApi.Services
{
    public interface ITypesOfAccountsService
    {
        IEnumerable<TypesOfAccounts> GetAll ();
        //bool EditTypeOfAccount(TypesOfAccounts account);
    }
}
