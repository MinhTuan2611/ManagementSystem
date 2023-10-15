using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IInventoryVoucherService
    {
        Task<InventoryVoucher> CreateInventoryVoucher(NewInventoryVoucherDto request);
        Task<InventoryVoucher> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request);
        Task<List<InventoryVoucherResponseDto>> GetInventoryVouchers(SearchCriteria searchModel);
        Task<List<InventoryVoucherDetailResponseDto>> GetInventoryVoucherDetail(int documentNumber);
    }
}
