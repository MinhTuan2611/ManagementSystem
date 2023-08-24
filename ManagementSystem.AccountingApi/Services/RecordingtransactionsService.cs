using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using Newtonsoft.Json.Linq;

namespace ManagementSystem.AccountingApi.Services
{
    public class RecordingtransactionsService : IRecordingtransactionsService
    {
        private readonly UnitOfWork _unitOfWork;

        public RecordingtransactionsService(AccountingDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<RecTransInfo> GetAll()
        {
            List<Recordingtransaction> recordTransDb = _unitOfWork.RecordingtransactionRepository.GetAll().ToList();
            if (recordTransDb.Any())
            {
                var recordTrans = recordTransDb.Select(r => new RecTransInfo
                {
                    Id = r.Id,
                    DocumentType = r.DocumentType,
                    ReasonGroup = r.ReasonGroup,
                    ReasonCode = r.ReasonCode,
                    ReasonName = r.ReasonName,
                    CreditAccountId = r.CreditAccountId,
                    DebitAccountId = r.DebitAccountId,
                    ExpenseItem = r.ExpenseItem,
                    Note = r.Note,
                    Status = r.Status,
                    
                });
                return recordTrans;
            }
            return null;
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
    }
}
