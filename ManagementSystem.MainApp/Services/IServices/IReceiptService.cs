using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;

namespace ManagementSystem.MainApp.Services.IServices
{
    public interface IReceiptService
    {
        Task<ResponseDto?> SearchReceipts(SearchCriteria criteria);
        Task<ResponseDto?> GetReceiptByDocumentNumber(int documentNumber);
        Task<ResponseDto?> CreateReceipt(NewReceiptRequestDto request);
        Task<ResponseDto?> UpdateReceipt(UpdateReceiptRequestDto request);
    }
}
