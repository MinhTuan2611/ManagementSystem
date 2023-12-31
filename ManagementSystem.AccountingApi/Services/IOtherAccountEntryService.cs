﻿
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IOtherAccountEntryService
    {
        Task<OtherAccountEntry> CreateAccountEntry(NewOtherAccountEntrydto newOtherAccountEntry);
        Task<OtherAccountEntry> UpdateAccountEntry(UpdateOtherAccountEntryDto updateOtherAccountEntry);
        Task<TPagination<OtherAccountEntryResponseDto>> GetOtherAccountEntries(int? page = 1, int? pageSize = 10);
        Task<OtherAccountEntryResponseDto> GetOtherAccountEntry(int documentId);
        public Task<TPagination<OtherAccountEntryResponseDto>> SearchOtherAccountEntries(SearchCriteria criteria);
    }
}
