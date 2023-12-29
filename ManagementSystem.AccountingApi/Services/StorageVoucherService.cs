using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Utility;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class StorageVoucherService : IStorageVoucherService
    {
        private readonly AccountingDbContext _context;
        private readonly IConfiguration _configuration;
        private ResponseDto _reponse;
        private readonly string _path = string.Empty;

        public StorageVoucherService(AccountingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _reponse = new ResponseDto();
            _path = @"C:\\Logs\\Accounting\\InventoryVoucher";
        }
        public async Task<ResponseDto> CreateProductStorage(BillRefundRequestDto request)
        {
            try
            {
                foreach (var item in request.ReturnedProduct)
                {
                    var productStorage = GetProductStorageDto(request.BranchId ?? 1, item.ProductId);

                    if (item.Reason == "HU")
                    {
                        string insertQuery = string.Format(@"
                        INSERT INTO {0}.dbo.ProductStorages (ProductId, StorageId, Quantity, CreateDate,
                        CreateBy, ModifyDate, ModifyBy)
                        VALUES ({1}, {2}, {3}, '{4}', {5}, '{6}',{7})
                    ", SD.StorageDbName, item.ProductId, productStorage.StorageId, item.Quantity, DateTime.Now, 1, DateTime.Now, 1);

                        var insertResult = _context.Database.ExecuteSqlRaw(insertQuery);
                    }
                    else
                    {
                        string query = string.Format(@"
                        UPDATE {0}.dbo.ProductStorages
                        SET Quantity = {1}
                            ,ModifyDate = GETDATE()
                        WHERE ProductId = {2}
                        AND StorageId = {3}
                    ", SD.StorageDbName, productStorage.Quantity + item.Quantity, item.ProductId, productStorage.StorageId);
                        var insertResult = _context.Database.ExecuteSqlRaw(query);
                    }
                }

                _reponse.Result = true;
                return _reponse;
            }
            catch (Exception ex)
            {
                _reponse.Result = false;
                _reponse.Message = ex.Message;
                return _reponse;
            }
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
    }
}