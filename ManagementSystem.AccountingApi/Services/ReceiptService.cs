using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly AccountingDbContext _context;
        public ReceiptService(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReceipt(NewReceiptRequestDto request)
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

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ReceiptResponseDto>> GetAllReceipts(int? page = 1, int? pageSize = 10)
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

                ORDER BY r.TransactionDate DESC
                OFFSET ({0}-1)*{1} ROWS
                FETCH NEXT {1} ROWS ONLY
            ", page, pageSize);

            try
            {
                var receipts = _context.ReceiptResponseDtos.FromSqlRaw(query).ToList();

                return receipts;
            }
            catch (Exception ex)
            {

                throw ex;
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

        public async Task<bool> UpdateReceipt(UpdateReceiptRequestDto request)
        {
            try
            {
                var receipt = _context.Receipts.FirstOrDefault(x => x.DocumentNumber == request.DocumentNumber);

                if (receipt == null)
                    return false;

                receipt.CustomerId = request.CustomerId;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
