﻿using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly AccountingDbContext _context;
        private readonly ILegerService _legerService;
        private IConfiguration _configuration;
        private ResponseDto _response;
        private readonly string _path = string.Empty;

        public ReceiptService(AccountingDbContext context, ILegerService legerService, IConfiguration configuration)
        {
            _context = context;
            _legerService = legerService;
            _configuration = configuration;
            _response = new ResponseDto();
            _path = @"C:\\Logs\\Accounting\\Receipt";
        }

        public async Task<ResponseDto> CreateReceipt(NewReceiptRequestDto request)
        {
            try
            {
                var receipt = new ReceiptVoucher();
                receipt.CustomerId = request.CustomerId;
                receipt.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;
                receipt.TransactionDate = DateTime.Now;
                receipt.GroupId = AccountingConstant.AutoGenerateDocumentGroup; // Auto Generate Group
                _context.ReceiptVouchers.Add(receipt);
                await _context.SaveChangesAsync();

                var accounts = GetAccountInfor(request.InventoryDocumentNumber);

                await _legerService.CreateLegers(new Leger()
                {
                    CustomerId = receipt.CustomerId,
                    CustomerName  = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty,
                    TransactionDate = receipt.TransactionDate,
                    DoccumentNumber = receipt.DocumentNumber,
                    CreditAccount = accounts?.CreditAccount,
                    DepositAccount = accounts?.DebitAccount,
                    DoccumentType = AccountingConstant.ReceiptType,
                    BillId = request.BillId,
                    Amount = request.TotalMoney,
                    UserId = request.UserId,
                    StorageId = request.StorageId,
                });

                _context.SaveChanges();

                _response.Result = receipt;
                return _response;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function CreateReceipt: " + ex.Message, _path);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        public async Task<ResponseDto> SearchReceipts(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);

                // Your DbContextFactory and DbContext creation code
                var dbContextFactory = new DbContextFactory(_configuration);
                using var dbContext = dbContextFactory.CreateDbContext<AccountingDbContext>("AcountingsDbConnStr");

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@xmlString", xmlString )
                };

                int pageNumber = criteria.PageNumber <= 0 ? 1 : criteria.PageNumber;
                int pageSize = criteria.PageSize <= 0 ? 10 : criteria.PageSize;

                var executeResult = await GenericSearchRepository<ReceiptResponseDto>.ExecutePagedStoredProcedureCommonAsync<ReceiptResponseDto>
                                                                                    (dbContext, "sp_SearchReceipts", pageNumber, pageSize, parameters);

                // Process the results
                List<ReceiptResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<ReceiptResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;

                _response.Result = result;
                return _response;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function SearchReceipts: " + ex.Message, _path);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        public async Task<ResponseDto> GetReceptByDocumentNumber(int documentNumbers)
        {
            string query = string.Format(@"
                SELECT r.DocumentNumber
		                ,r.TransactionDate
		                ,c.CustomerId
		                ,c.CustomerName
		                ,c.CustomerName AS Payer
		                ,r.ForReason
		                ,r.TotalMoney
		                ,u.UserId
		                ,u.UserName AS Cashier
                        ,lg.DepositAccount AS DebitAccount
						,lg.CreditAccount AS CreditAccount
                FROM ReceiptVouchers r
                LEFT JOIN {0}.dbo.Customers c ON r.CustomerId = c.CustomerId
                LEFT JOIN {1}.dbo.Users u ON u.UserId = r.UserId
                LEFT JOIN dbo.Legers lg ON lg.DoccumentType = N'THU' and lg.DoccumentNumber = r.DocumentNumber
                WHERE r.DocumentNumber = {2}
            ",SD.StorageDbName, SD.AccountDbName, documentNumbers);

            try
            {
                var receipts = _context.ReceiptResponseDtos.FromSqlRaw(query).FirstOrDefault();

                _response.Result = receipts;

                return _response;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetReceptByDocumentNumber: " + ex.Message, _path);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        public async Task<ResponseDto> UpdateReceipt(UpdateReceiptRequestDto request)
        {
            try
            {
                var receipt = _context.ReceiptVouchers.FirstOrDefault(x => x.DocumentNumber == request.DocumentNumber);

                if (receipt == null)
                    return null;

                receipt.CustomerId = request.CustomerId;
                receipt.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;

                await _context.SaveChangesAsync();

                _response.Result = receipt;
                return _response;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function UpdateReceipt: " + ex.Message, _path);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        #region Private Handle function
        private AccountsDto GetAccountInfor(int documentNumber)
        {
            var query = string.Format(@"
                SELECT tc.AccountCode AS CreditAccount
		                ,td.AccountCode AS DebitAccount
                FROM dbo.InventoryVouchers i
                JOIN dbo.Recordingtransactions rt ON i.ReasonFor = rt.ReasonCode
                JOIN dbo.TypesOfAccounts tc ON tc.AccountId = rt.CreditAccountId
                JOIN dbo.TypesOfAccounts td ON td.AccountId = rt.DebitAccountId
                WHERE i.DocummentNumber = {0}
            ", documentNumber);

            try
            {
                var result = _context.AccountDtos.FromSqlRaw(query).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
