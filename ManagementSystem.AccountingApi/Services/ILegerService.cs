using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface ILegerService
    {
        public Task<List<LegerResponseDto>> GetAllLegerInformation(int pageNumber, int pageSize);
    }
}
