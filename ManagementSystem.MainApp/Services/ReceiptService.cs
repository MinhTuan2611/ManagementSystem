using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Models;
using ManagementSystem.MainApp.Services.IServices;
using ManagementSystem.MainApp.Utility;
using static ManagementSystem.MainApp.Utility.SD;

namespace ManagementSystem.MainApp.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IBaseService _service;
        public ReceiptService(IBaseService service)
        {
            _service = service;
        }

        public async Task<ResponseDto?> CreateReceipt(NewReceiptRequestDto request)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "Receipt/create",
                Data = request
            });
        }

        public async Task<ResponseDto?> GetReceiptByDocumentNumber(int documentNumber)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.AccountingApiUrl + "Receipt/get-by-document-number?documentNumber=" + documentNumber
            });
        }

        public async Task<ResponseDto?> SearchReceipts(SearchCriteria criteria)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "Receipt/search_results",
                Data = criteria

            });
        }

        public async Task<ResponseDto?> UpdateReceipt(UpdateReceiptRequestDto request)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = SD.AccountingApiUrl + "Receipt/update",
                Data = request
            });
        }
    }
}
