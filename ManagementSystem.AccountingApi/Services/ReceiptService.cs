using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;

        public ReceiptService(AccountingDbContext context, ILegerService legerService)
        {
            _context = context;
            _legerService = legerService;

        }

        public async Task<Receipt> CreateReceipt(NewReceiptRequestDto request)
        {
            try
            {
                var receipt = new Receipt();
                receipt.CustomerId = request.CustomerId;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;
                receipt.TransactionDate = DateTime.Now;

                _context.Receipts.Add(receipt);
                await _context.SaveChangesAsync();

                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = receipt.CustomerId,
                    TransactionDate = receipt.TransactionDate,
                    DoccumentNumber = receipt.DocumentNumber,
                    CreditAccount = request.CreditAccountId,
                    DepositAccount = request.DebitAccountId,
                    DoccumentType = AccountingConstant.InventoryDeliveryDocummentType,
                    BillId = request.BillId,
                    Amount = request.TotalMoney,
                    UserId = request.UserId,
                    StorageId = request.StorageId,
                });

                _context.SaveChanges();

                return receipt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ReceiptResponseDto>> GetAllReceipts(SearchCriteria searchModel)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(searchModel);
                var result = _context.ReceiptResponseDtos.FromSqlRaw(string.Format("EXEC sp_SearchReceipts '{0}', {1}, {2}", xmlString, searchModel.PageNumber, searchModel.PageSize)).AsNoTracking().ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReceiptResponseDto> GetReceptByDocumentNumber(int documentNumbers)
        {
            string query = string.Format(@"
                SELECT r.DocumentNumber
		                ,r.TransactionDate
		                ,c.CustomerId
		                ,c.CustomerName
		                ,c.CustomerName AS Payer
		                ,r.ForReason
		                ,r.TotalMoney
		                ,u.UserId
		                ,u.UserName AS Cashier
                FROM Receipts r
                JOIN StoragesDB.dbo.Customers c ON r.CustomerId = c.CustomerId
                JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
                WHERE r.DocumentNumber = {0}
            ", documentNumbers);

            var receipts = _context.ReceiptResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return receipts;
        }

        public async Task<Receipt> UpdateReceipt(UpdateReceiptRequestDto request)
        {
            try
            {
                var receipt = _context.Receipts.FirstOrDefault(x => x.DocumentNumber == request.DocumentNumber);

                if (receipt == null)
                    return null;

                receipt.CustomerId = request.CustomerId;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;

                await _context.SaveChangesAsync();

                return receipt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
