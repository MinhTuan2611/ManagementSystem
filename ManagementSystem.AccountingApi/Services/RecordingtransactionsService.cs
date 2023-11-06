using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace ManagementSystem.AccountingApi.Services
{
    public class RecordingtransactionsService : IRecordingtransactionsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AccountingDbContext _context;
        private readonly string _path = string.Empty;

        public RecordingtransactionsService(AccountingDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _context = context;
            _path = @"C:\\Logs\\Accounting\\Recordingtransaction";
        }

        public IEnumerable<RecTransInfoResponseDto> GetAll()
        {
            var result  = GetAllTransactionInfo();
            return result;
        }
        public bool EditRecordTrans(int recordId, RecTransInfo record, int userId)
        {
            Recordingtransaction recordTrans= _unitOfWork.RecordingtransactionRepository.GetByID(recordId);
            if (recordTrans != null)
            {
                recordTrans.DocumentType = record.DocumentType;
                recordTrans.ReasonGroup = record.ReasonGroup;
                recordTrans.ReasonCode = record.ReasonCode;
                recordTrans.ReasonName = record.ReasonName;
                recordTrans.CreditAccountId = record.CreditAccountId;
                recordTrans.DebitAccountId = record.DebitAccountId;
                recordTrans.ExpenseItem = record.ExpenseItem;
                recordTrans.Note = record.Note;
                recordTrans.ModifyDate = DateTime.Now;
                recordTrans.ModifyBy = userId;
                try
                {
                    _unitOfWork.RecordingtransactionRepository.Update(recordTrans);
                    _unitOfWork.Save();
                    _unitOfWork.Dispose();
                    return true;
                } catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool DeleteRecordTrans(int recordId, int userId)
        {
            Recordingtransaction recordTrans = _unitOfWork.RecordingtransactionRepository.GetByID(recordId);
            if (recordTrans != null)
            {
                recordTrans.Status = ActiveStatus.Inactive;
                recordTrans.ModifyDate = DateTime.Now;
                recordTrans.ModifyBy = userId;
                try
                {
                    _unitOfWork.RecordingtransactionRepository.Update(recordTrans);
                    _unitOfWork.Save();
                    _unitOfWork.Dispose();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool CreateRecordTrans(RecTransInfo value, int userId)
        {
            Recordingtransaction record = new Recordingtransaction
            {
                DocumentType = value.DocumentType,
                ExpenseItem = value.ExpenseItem,
                Note = value.Note,
                ReasonGroup = value.ReasonGroup,
                ReasonCode = value.ReasonCode,
                ReasonName = value.ReasonName,
                DebitAccountId = value.DebitAccountId,
                CreditAccountId = value.CreditAccountId,
                CreateBy = userId,
                CreateDate = DateTime.Now,
            };
            try
            {
                _unitOfWork.RecordingtransactionRepository.Insert(record);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Private handle function
        private List<RecTransInfoResponseDto> GetAllTransactionInfo()
        {
            string query = @"
                SELECT rt.Id
		                ,rt.DocumentType
		                ,rt.ReasonGroup
		                ,rt.ReasonCode
		                ,rt.ReasonName
		                ,td.AccountCode AS DebitAccountId
		                ,tc.AccountCode  AS CreditAccountId
		                ,rt.Status
		                ,rt.ExpenseItem
		                ,rt.Note
                FROM dbo.Recordingtransactions rt
                JOIN dbo.TypesOfAccounts tc ON tc.AccountId = rt.CreditAccountId
                JOIN dbo.TypesOfAccounts td ON td.AccountId = rt.DebitAccountId
            ";

            try
            {
                var result = _context.ExecuteSqlForEntity<RecTransInfoResponseDto>(query).ToList();

                return result;
            }
            catch(Exception ex)
            {
                var logger = new LogWriter("Function GetAllTransactionInfo: " + ex.Message, _path);
                return null;
            }
        }
        #endregion
    }
}
