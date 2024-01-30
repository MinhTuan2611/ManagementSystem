using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IInventoryVoucherService
    {
        Task<ResponseDto> CreateInventoryVoucher(NewInventoryVoucherDto request, bool isRefundItem = false);
        Task<ResponseDto> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request);
        Task<ResponseDto> SearchInventoryVouchers(SearchCriteria criteria);
        Task<ResponseDto> GetInventoryVoucherDetail(int documentNumber);
        Task<ResponseDto> GetInventoryVoucherById(int documentNumber);
    }
}
