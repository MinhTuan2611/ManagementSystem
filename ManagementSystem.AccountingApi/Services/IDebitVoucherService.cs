using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IDebitVoucherService
    {
        public Task<DebitVoucher> CreateDebitVoucher(NewDebitVoucherRequestDto requestDto);
        public Task<DebitVoucher> UpdateDebitVoucher(UpdateDebitVoucherRequestDto requestDto);
        Task<TPagination<DebitVoucherResponseDto>> SearchDebitVouchers(SearchCriteria searchModel);
        Task<DebitVoucherResponseDto> GetDebitVouchereByDocumentNumber(int documentNumber);
    }
}
