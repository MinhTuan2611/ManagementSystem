using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Models;
using ManagementSystem.MainApp.Services.IServices;
using ManagementSystem.MainApp.Utility;
using static ManagementSystem.MainApp.Utility.SD;

namespace ManagementSystem.MainApp.Services
{
    public class InventoryVoucherService : IInventoryVoucherService
    {
        private readonly IBaseService _baseService;
        public InventoryVoucherService(IBaseService baseService)
        {

            _baseService = baseService;

        }

        public async Task<ResponseDto?> CreateInventory(NewInventoryVoucherDto request)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "InventoryVoucher/create",
                Data = request
            });
        }

        public async Task<ResponseDto?> GetInventoryByDocumentNumber(int documentNumber)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.AccountingApiUrl + "InventoryVoucher/get-by-document-number?documentNumber=" + documentNumber
            });
        }

        public async Task<ResponseDto?> GetInventoryDetailByDocumentNumber(int documentNumber)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.AccountingApiUrl + "InventoryVoucher/get-detail-by-document-number?documentNumber=" + documentNumber
            });
        }

        public async Task<ResponseDto?> SearchInventory(SearchCriteria criteria)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "InventoryVoucher/search_results",
                Data = criteria

            });
        }

        public async Task<ResponseDto?> UpdateInventory(UpdateInventoryVoucherDto request)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "InventoryVoucher/update",
                Data = request
            });
        }
    }
}
