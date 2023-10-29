using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IDocumentGroupService
    {
        public Task<TPagination<DocumentGroupResponseDto>> GetAllLegerInformation(SearchCriteria criteria);
    }
}
