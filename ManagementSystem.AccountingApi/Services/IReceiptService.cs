using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IReceiptService
    {
        Task<Receipt> CreateReceipt(NewReceiptRequestDto request);
        Task<Receipt> UpdateReceipt(UpdateReceiptRequestDto request);
        Task<TPagination<ReceiptResponseDto>> GetAllReceipts(SearchCriteria searchModel);
        Task<ReceiptResponseDto> GetReceptByDocumentNumber(int documentNumber);
    }
}
