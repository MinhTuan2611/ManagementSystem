using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IPaymentVoucherService
    {
        public Task<PaymentVoucher> CreatePaymentVoucher(NewPaymentVoucherDto newPaymentVoucher);
        public Task<PaymentVoucher> UpdatePaymentVoucher(UpdatePaymentVoucherDto updatePaymentVoucher);
        public Task<TPagination<PaymentVoucherResponseDto>> GetPaymentVouchers(int? page = 1, int? pageSize = 10);
        public Task<PaymentVoucherResponseDto> GetPaymentVoucher(int DocumentId);

        public Task<TPagination<PaymentVoucherResponseDto>> SearchPaymentVoucherInformation(SearchCriteria criteria);
    }
}
