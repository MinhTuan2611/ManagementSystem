using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IStorageVoucherService
    {
        Task CreateProductStorage(List<ReturnedProductRequestDto> request);
    }
}