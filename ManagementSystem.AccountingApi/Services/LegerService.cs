using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.GenericRepository;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class LegerService : ILegerService
    {
        private readonly AccountingDbContext _context;
        public LegerService(AccountingDbContext context)
        {
            _context = context;
        }

        public LegerService()
        {
            
        }

        public async Task<List<LegerResponseDto>> GetAllLegerInformation(int pageNumber, int pageSize)
        {
            // await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize)

            // Lay Thong Tin Phieu Thu
            var receipers = await PaginatedList<Receipt>.CreateAsync(_context.Receipts.OrderByDescending(x => x.TransactionDate)
                                                                        .AsNoTracking(), pageNumber, pageSize);


            // Lay Thong Tin Phieu Chi
            var paymentVouchers = await PaginatedList<PaymentVoucher>.CreateAsync(_context.PaymentVouchers.OrderByDescending(x => x.TransactionDate)
                                                                        .AsNoTracking(), pageNumber, pageSize);

            // Lay Thong Tin Phieu Xuat
            var inventoryDeliveryVouchers = await PaginatedList<InventoryVoucher>.CreateAsync(_context.InventoryVouchers
                                                                            .Include(x => x.Details)
                                                                            .OrderByDescending(x => x.TransactionDate)
                                                                            .AsNoTracking(), pageNumber, pageSize);

            var legers = new List<LegerResponseDto>();

            foreach (var item in receipers)
            {
                legers.Add(new LegerResponseDto()
                {
                    TransactionDate = item.TransactionDate.ToString("dd/MM/yyyy"),
                    CreitAccount = 0,
                    DebitAccount = 0,
                    DoccumentNumer = item.DocumentNumber,
                    DocumentType = AccountingConstant.ReceiptType,
                    UserId = item.UserId,
                    Username = "",
                    TotalMoney = item.TotalMoney,
                });
            
            }

            foreach (var item in paymentVouchers)
            {
                legers.Add(new LegerResponseDto() { });
            }

            foreach (var item in inventoryDeliveryVouchers)
            {
                legers.Add(new LegerResponseDto() { });
            }

            return null;
        }
    }
}
