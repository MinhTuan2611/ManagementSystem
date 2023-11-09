﻿using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
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

        public ReceiptService(AccountingDbContext context, ILegerService legerService, IConfiguration configuration)
        {
            _context = context;
            _legerService = legerService;
            _configuration = configuration;

        }

        public async Task<ReceiptVoucher> CreateReceipt(NewReceiptRequestDto request)
        {
            try
            {
                var receipt = new ReceiptVoucher();
                receipt.CustomerId = request.CustomerId;
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

                return receipt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TPagination<ReceiptResponseDto>> SearchReceipts(SearchCriteria criteria)
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
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReceiptResponseDto> GetReceptByDocumentNumber(int documentNumbers)
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
                LEFT JOIN StoragesDB.dbo.Customers c ON r.CustomerId = c.CustomerId
                LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
                LEFT JOIN dbo.Legers lg ON lg.DoccumentType = N'THU' and lg.DoccumentNumber = r.DocumentNumber
                WHERE r.DocumentNumber = {0}
            ", documentNumbers);

            var receipts = _context.ReceiptResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return receipts;
        }

        public async Task<ReceiptVoucher> UpdateReceipt(UpdateReceiptRequestDto request)
        {
            try
            {
                var receipt = _context.ReceiptVouchers.FirstOrDefault(x => x.DocumentNumber == request.DocumentNumber);

                if (receipt == null)
                    return null;

                receipt.CustomerId = request.CustomerId;
                receipt.ForReason = request.ForReason;
                receipt.TotalMoney = request.TotalMoney;
                receipt.UserId = request.UserId;

                await _context.SaveChangesAsync();

                return receipt;
            }
            catch (Exception ex)
            {
                return null;
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
                return null;
            }
        }
        #endregion

    }
}
