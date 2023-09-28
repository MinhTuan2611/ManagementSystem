using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IInventoryVoucherService
    {
        Task<InventoryVoucher> CreateInventoryVoucher(NewInventoryVoucherDto request);
        Task<bool> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request);
        Task<List<InventoryVoucherResponseDto>> GetInventoryVouchers(int page, int pageSize);
        Task<List<InventoryVoucherDetailResponseDto>> GetInventoryVoucherDetail(int documentNumber);
    }
}
