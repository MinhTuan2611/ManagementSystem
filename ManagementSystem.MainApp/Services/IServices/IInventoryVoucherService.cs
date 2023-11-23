using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.MainApp.Services.IServices
{
    public interface IInventoryVoucherService
    {
        Task<ResponseDto?> SearchInventory(SearchCriteria criteria);
        Task<ResponseDto?> GetInventoryDetailByDocumentNumber(int documentNumber);
        Task<ResponseDto?> GetInventoryByDocumentNumber(int documentNumber);
        Task<ResponseDto?> CreateInventory(NewInventoryVoucherDto request);
        Task<ResponseDto?> UpdateInventory(UpdateInventoryVoucherDto request);
    }
}
