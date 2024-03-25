using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IRefundService
    {
        Task<bool> CreateRefundVoucher(BillRefundRequestDto model);
    }
}
