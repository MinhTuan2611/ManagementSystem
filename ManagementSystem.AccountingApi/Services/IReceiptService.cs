using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IReceiptService
    {
        Task<ResponseDto> CreateReceipt(NewReceiptRequestDto request);
        Task<ResponseDto> UpdateReceipt(UpdateReceiptRequestDto request);
        Task<ResponseDto> SearchReceipts(SearchCriteria searchModel);
        Task<ResponseDto> GetReceptByDocumentNumber(int documentNumber);
    }
}
