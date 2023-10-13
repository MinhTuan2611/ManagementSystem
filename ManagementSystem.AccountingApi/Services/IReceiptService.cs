using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IReceiptService
    {
        Task<Receipt> CreateReceipt(NewReceiptRequestDto request);
        Task<Receipt> UpdateReceipt(UpdateReceiptRequestDto request);
        Task<List<ReceiptResponseDto>> GetAllReceipts(int? page = 1, int? pageSize = 10);
        Task<ReceiptResponseDto> GetReceptByDocumentNumber(int documentNumber);
    }
}
