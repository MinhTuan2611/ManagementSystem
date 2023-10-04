using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos.Accounting;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IOtherAccountEntryService
    {
        Task<OtherAccountEntry> CreateAccountEntry(NewOtherAccountEntrydto newOtherAccountEntry);
        Task<OtherAccountEntry> UpdateAccountEntry(UpdateOtherAccountEntryDto updateOtherAccountEntry);
        Task<List<OtherAccountEntryResponseDto>> GetOtherAccountEntries(int? page = 1, int? pageSize = 10);
        Task<OtherAccountEntryResponseDto> GetOtherAccountEntry(int documentId);
    }
}
