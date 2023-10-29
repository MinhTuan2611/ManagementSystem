using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface ICreditVoucherService
    {
        Task<CreditVoucher> CreateCreditVoucher(NewCreditVoucherRequestDto request);
        Task<CreditVoucher> UpdateCreditVoucher(UpdateCreditVoucherRequestDto request);
        Task<TPagination<CreditVoucherResponseDto>> GetAllCreditVouchers(SearchCriteria searchModel);
        Task<CreditVoucherResponseDto> GetCreditVouchereByDocumentNumber(int documentNumber);
    }
}
