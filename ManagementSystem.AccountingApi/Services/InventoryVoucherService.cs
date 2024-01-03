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
    public class InventoryVoucherService : IInventoryVoucherService
    {
        private readonly AccountingDbContext _context;
        private readonly IConfiguration _configuration;
        private ResponseDto _reponse;
        private readonly string _path = string.Empty;

        public InventoryVoucherService(AccountingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _reponse = new ResponseDto();
            _path = @"C:\\Logs\\Accounting\\InventoryVoucher";
        }

        public async Task<ResponseDto> CreateInventoryVoucher(NewInventoryVoucherDto request)
        {
            try
            {
                var inventory = new InventoryVoucher();
                var accountInfor = GetAccountInfor(AccountingConstant.XBAReason);
                inventory.UserId = request.UserId;
                inventory.PurchasingRepresentive = request.PurchasingRepresentive;
                inventory.TransactionDate = DateTime.Now;
                inventory.ReasonFor = AccountingConstant.XBAReason;
                inventory.Note = request.Note;
                inventory.RepresentivePhone = "";
                inventory.CustomerId = request.CustomerId;
                inventory.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                inventory.StorageId = GetProductStorageDto(request.BrandId ?? 1, request.Details[0].ProductId)?.StorageId ?? null;
                inventory.BillId = request.BillId;
                inventory.GroupId = AccountingConstant.AutoGenerateDocumentGroup; // The auto build group
                inventory.CreditAccount = accountInfor?.CreditAccount;
                inventory.DebitAccount = accountInfor?.DebitAccount;

                _context.InventoryVouchers.Add(inventory);
                _context.SaveChanges();

                foreach (var detail in request.Details)
                {
                    var product = GetProductInformation(detail.ProductId);
                    var unit = GetUnitInformation(detail.UnitId);
                    var productStorage = GetProductStorageDto(request.BrandId ?? 1, detail.ProductId);

                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = inventory.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.UnitId = detail.UnitId;
                    item.CreditAccount = product?.CreditAccountId;
                    item.DebitAccount = product?.DebitAccountId;
                    //item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    //item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = product?.PriceBeforeTax;
                    item.TotalMoneyBeforeTax = product != null ? product.PriceBeforeTax * detail.Quantity : 0;
                    item.DebitAccountMoney = detail.TotalMoneyAfterTax;
                    item.CreditAccountMoney = detail.TotalMoneyAfterTax;
                    item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    //item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return null;
                    }
                }

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Create Inventory Voucher: " + inventory.DocummentNumber.ToString(),
                    Source = "InventoryDeliveryVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                _reponse.Result = inventory;
                return _reponse;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function CreateInventoryVoucher: " + ex.Message, _path);
                _reponse.IsSuccess = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
        }

        public async Task<ResponseDto> UpdateInventoryDeliveryVoucher(UpdateInventoryVoucherDto request)
        {
            try
            {
                var inventory = _context.InventoryVouchers.Include(x => x.Details)
                                                            .FirstOrDefault(x => x.DocummentNumber == request.DocummentNumber);
                if (inventory == null)
                    return null;

                var accountInfor = GetAccountInfor(request.ReasonFor);

                // inventory.UserId = request.UserId;
                inventory.PurchasingRepresentive = request.PurchasingRepresentive;
                inventory.RepresentivePhone = request.RepresentivePhone;
                inventory.ReasonFor = request.ReasonFor;
                inventory.Note = request.Note;
                inventory.CustomerId = request.CustomerId;
                inventory.CustomerName = request.CustomerId == null && request.CustomerName != null ? request.CustomerName : string.Empty;
                inventory.CreditAccount = accountInfor?.CreditAccount;
                inventory.DebitAccount = accountInfor?.DebitAccount;
                _context.SaveChanges();

                _context.InventoryVoucherDetails.RemoveRange(inventory.Details);

                foreach (var detail in request.Details)
                {
                    var product = GetProductInformation(detail.ProductId);
                    var unit = GetUnitInformation(detail.UnitId);
                    var productStorage = GetProductStorageDto(request.BrandId.Value, detail.ProductId);

                    var item = new InventoryVoucherDetail();
                    item.DocummentNumber = inventory.DocummentNumber;
                    item.ProductId = detail.ProductId;
                    item.CreditAccount = product.CreditAccountId;
                    item.DebitAccount = product.DebitAccountId;
                    //item.PaymentDiscountAccount = detail.PaymentDiscountAccount;
                    //item.TaxAccount = detail.TaxAccount;
                    item.Quantity = detail.Quantity;
                    item.Price = product.PriceBeforeTax;
                    item.TotalMoneyBeforeTax = product.PriceBeforeTax * detail.Quantity;
                    item.DebitAccountMoney = detail.TotalMoneyAfterTax;
                    item.CreditAccountMoney = detail.TotalMoneyAfterTax;
                    //item.PaymentDiscountMoney = detail.PaymentDiscountMoney;
                    //item.TaxMoney = detail.TaxMoney;
                    item.TotalMoneyAfterTax = detail.TotalMoneyAfterTax;
                    item.Note = detail.Note;

                    _context.InventoryVoucherDetails.Add(item);

                    if (productStorage != null)
                    {
                        bool result = UpdateProductStorage(productStorage, detail.Quantity);

                        if (!result)
                            return null;
                    }
                }

                await _context.SaveChangesAsync();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Update Inventory Voucher: " + inventory.DocummentNumber.ToString(),
                    Source = "InventoryDeliveryVoucher",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                _reponse.Result = inventory;
                return _reponse;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function UpdateInventoryVoucher: " + ex.Message, _path);
                _reponse.IsSuccess = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
        }

        public async Task<ResponseDto> GetInventoryVoucherById(int documentNummer)
        {
            string query = string.Format(@"
                                        SELECT DISTINCT iv.DocummentNumber
												,iv.CustomerId
												,c.CustomerName
												,iv.PurchasingRepresentive
												,iv.RepresentivePhone
												,iv.Note
												,iv.UserId
												,u.FirstName
												,u.LastName
												,u.Email
												,u.PhoneNumber
												,iv.ReasonFor
									--            ,p.PaymentMethodName
												--,p.PaymentMethodCode
												--,bp.Amount AS PaymentAmount
												,iv.TransactionDate
												,s.StorageName
												,iv.CreditAccount AS InventoryCreditAccount
												,iv.DebitAccount AS InventoryDebitAccount
												,iv.BillId
										FROM InventoryVouchers iv
										LEFT JOIN {0}.dbo.BillPayments bp ON bp.BillId = iv.BillId
										-- LEFT JOIN {0}.dbo.PaymentMethods p On bp.PaymentMethodId = p.PaymentMethodId
										LEFT JOIN {0}.dbo.customers c ON iv.CustomerId = c.CustomerId
										LEFT JOIN {1}.dbo.Users u ON iv.UserId = u.UserId
										LEFT JOIN {0}.dbo.Storages s ON s.StorageId = iv.StorageId
										WHERE iv.DocummentNumber = {2}
            ",SD.StorageDbName, SD.AccountDbName, documentNummer);

            try
            {
                var result = _context.InventoryVoucherResponseDto.FromSqlRaw(query).SingleOrDefault();

                _reponse.Result = result;
                return _reponse;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetInventoryVoucherById: " + ex.Message, _path);
                _reponse.IsSuccess = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
        }

        public async Task<ResponseDto> GetInventoryVoucherDetail(int documentNumber)
        {
            string query = string.Format(@"
                 SELECT p.ProductId
                         ,p.ProductName
                         ,p.ProductCode
		                 ,p.DefaultPurchasePrice
		                 ,p.BarCode
		                 ,p.Tax
                         ,u.UnitName
                         ,p.Price
                         ,details.Quantity
                         ,details.debitaccount
                         ,details.creditaccount
                         ,details.PaymentDiscountAccount
                         ,details.TaxAccount
                         ,details.TotalMoneyBeforeTax
                         ,details.DebitAccountMoney
                         ,details.CreditAccountMoney
                         ,details.PaymentDiscountMoney
                         ,details.TotalMoneyAfterTax
                         ,details.Note
                         ,details.TaxMoney
                 FROM InventoryVoucherDetails details
                 LEFT JOIN {0}.dbo.Products p ON p.ProductId = details.ProductId
                 LEFT JOIN {0}.dbo.ProductUnit pu ON p.ProductId = pu.ProductId
                 LEFT JOIN {0}.dbo.Unit u ON pu.UnitId = u.UnitId
                WHERE details.DocummentNumber = {1}
            ",SD.StorageDbName, documentNumber);

            try
            {
                var results = _context.InventoryVoucherDetailResponses.FromSqlRaw(query).ToList();

                _reponse.Result = results;
                return _reponse;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetInventoryVoucherDetail: " + ex.Message, _path);
                _reponse.IsSuccess = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
        }

        public async Task<ResponseDto> SearchInventoryVouchers(SearchCriteria criteria)
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

                var executeResult = await GenericSearchRepository<InventoryVoucherResponseDto>.ExecutePagedStoredProcedureCommonAsync<InventoryVoucherResponseDto>
                                                                                    (dbContext, "sp_SearchInventoryVoucher", pageNumber, pageSize, parameters);

                // Process the results
                List<InventoryVoucherResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;



                List<InventoryVoucherResponseDto> response = new List<InventoryVoucherResponseDto>();
                foreach (var item in pagedData)
                {
                    if (item.BillId != null)
                    {
                        var billPaymentMethods = await GetBillPaymentMethods(item.BillId.Value);

                        item.PaymentMethods = billPaymentMethods;
                    }
                    response.Add(item);
                }

                var result = new TPagination<InventoryVoucherResponseDto>();
                result.Items = response;
                result.TotalItems = totalRecords;

                _reponse.Result = result;
                return _reponse;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function SearchInventoryVouchers: " + ex.Message, _path);
                _reponse.IsSuccess = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
        }

        public PaymentMethodResponseDto GetPaymentInformation(string paymentMethodCode)
        {
            string query = string.Format(@"
                    SELECT PaymentMethodId
                    FROM {0}.dbo.PaymentMethods p
                    WHERE p.PaymentMethodCode = '{1}'
            ",SD.StorageDbName, paymentMethodCode);

            var paymentMethod = _context.PaymentMethodResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return paymentMethod;
        }

        public UnitResponseDto GetUnitInformation(int unitId)
        {
            string query = string.Format(@"
                    SELECT UnitName
                    FROM {0}.dbo.Unit u
                    WHERE u.UnitId = {1}
            ",SD.StorageDbName, unitId);

            var unit = _context.UnitResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return unit;
        }

        public ProductStorageInformationDto GetProductStorageDto(int brandId, int productId)
        {
            string query = string.Format(@"
                SELECT s.StorageId
		                ,ps.ProductId
		                ,COALESCE(ps.Quantity, 0) AS Quantity
                FROM {0}.dbo.Storages s
                LEFT JOIN {0}.dbo.ProductStorages ps ON s.StorageId = ps.StorageId
                WHERE s.BranchId = {1}
                AND ps.ProductId = {2}
            ",SD.StorageDbName, brandId, productId);

            try
            {
                var productStorage = _context.ProductStorageInformationDtos.FromSqlRaw(query).FirstOrDefault();

                return productStorage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProductStorage(ProductStorageInformationDto dto, float productQuantity)
        {
            //if (dto.Quantity - productQuantity <= 0)
            //    return false;

            string query = string.Format(@"
                UPDATE {0}.dbo.ProductStorages
                SET Quantity = {1}
                    ,ModifyDate = GETDATE()
                WHERE ProductId = {2}
                AND StorageId = {3}
            ", SD.StorageDbName, dto.Quantity - productQuantity, dto.ProductId, dto.StorageId);

            var result = _context.Database.ExecuteSqlRaw(query);

            return result == 0 ? false : true;
        }

        #region Private Function Handle
        private async Task<List<BillPaymentDetailResponseDto>> GetBillPaymentMethods(int billId)
        {
            string query = string.Format(@"
 	                SELECT b.Id
			                ,b.Amount
			                ,b.PaymentTransactionRef
			                ,p.PaymentMethodCode
			                ,P.PaymentMethodName
	                FROM {0}.dbo.BillPayments b
	                JOIN {0}.dbo.PaymentMethods p ON b.PaymentMethodId = p.PaymentMethodId
	                WHERE b.BillId = {1}
            ",SD.StorageDbName, billId);

            try
            {
                var result = _context.BillPaymentDetailResponseDtos.FromSqlRaw(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ProductResponseDto GetProductInformation(int productId)
        {
            string query = string.Format(@"
                    SELECT	p.ProductName
		                    ,p.Price
		                    ,p.Price * (1 + Tax/100) AS PriceBeforeTax
		                    ,p.CreditAccountId
		                    ,p.DebitAccountId
                    FROM {0}.dbo.Products p
                    WHERE p.ProductId = {1}
            ",SD.StorageDbName, productId);

            var product = _context.ProductResponseDtos.FromSqlRaw(query).FirstOrDefault();

            return product;
        }

        private AccountsDto GetAccountInfor(string reasonCode)
        {
            var query = string.Format(@"
                SELECT tc.AccountCode AS CreditAccount
                        ,td.AccountCode AS DebitAccount
                FROM  dbo.Recordingtransactions rt
                JOIN dbo.TypesOfAccounts tc ON tc.AccountId = rt.CreditAccountId
                JOIN dbo.TypesOfAccounts td ON td.AccountId = rt.DebitAccountId
                WHERE rt.ReasonCode = 'XBA'
            ", reasonCode);

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
