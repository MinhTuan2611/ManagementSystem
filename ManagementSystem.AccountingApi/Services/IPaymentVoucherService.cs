using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IPaymentVoucherService
    {
        public Task<PaymentVoucher> CreatePaymentVoucher(NewPaymentVoucherDto newPaymentVoucher);
        public Task<PaymentVoucher> UpdatePaymentVoucher(UpdatePaymentVoucherDto updatePaymentVoucher);
        public Task<List<PaymentVoucherResponseDto>> GetPaymentVouchers(int? page = 1, int? pageSize = 10);
        public Task<PaymentVoucherResponseDto> GetPaymentVoucher(int DocumentId);
    }
}
