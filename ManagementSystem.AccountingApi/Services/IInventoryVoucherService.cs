using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IInventoryVoucherService
    {
        Task<InventoryVoucher> CreateInventoryVoucher(NewInventoryVoucherDto request);
        Task<InventoryVoucher> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request);
        Task<TPagination<InventoryVoucherResponseDto>> SearchInventoryVouchers(SearchCriteria criteria);
        Task<List<InventoryVoucherDetailResponseDto>> GetInventoryVoucherDetail(int documentNumber);
        Task<InventoryVoucherResponseDto> GetInventoryVoucherById(int documentNumber);
    }
}
