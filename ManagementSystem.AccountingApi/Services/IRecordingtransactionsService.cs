using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IRecordingtransactionsService
    {
        IEnumerable<RecTransInfo> GetAll();
        bool EditRecordTrans(int recordId, RecTransInfo record, int userId);
        bool DeleteRecordTrans(int recordId, int userId);
        bool CreateRecordTrans(RecTransInfo record, int userId);
    }
}
