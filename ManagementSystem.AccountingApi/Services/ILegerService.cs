﻿using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface ILegerService
    {
        public Task<TPagination<LegerResponseDto>> GetAllLegerInformation(SearchCriteria model);
        public Task<Leger> CreateLegers(Leger leger);

        public Task<ResponseDto> ExportExcelFile(SearchCriteria model);
        public Task<ResponseDto> ExportLeggerWithoutPaymentExcelFile(SearchCriteria model);
        public Task<ResponseDto> ExportPaymentVouchersInformationExcelFile(SearchCriteria model);
        public Task<List<PaymentMethodInformationDto>> ViewPaymentVoucherInformation(SearchCriteria model);
    }
}
