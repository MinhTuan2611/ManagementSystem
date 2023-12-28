using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class StorageVoucherService : IStorageVoucherService
    {
        private readonly StoragesDbContext _storagesDbContext;
        private readonly IConfiguration _configuration;
        private ResponseDto _reponse;
        private readonly string _path = string.Empty;

        public StorageVoucherService(StoragesDbContext storagesDbContext,  IConfiguration configuration)
        {
            _storagesDbContext = storagesDbContext;
            _configuration = configuration;
            _reponse = new ResponseDto();
            _path = @"C:\\Logs\\Accounting\\InventoryVoucher";
        }
        public async Task CreateProductStorage(List<ReturnedProductRequestDto> request)
        {
            try
            {
                foreach (var item in request)
                {
                    var productStorage = new ProductStorage()
                    {
                        ProductId = item.ProductId,
                        StorageId = item.Reason == "HU" ? 3 : 1,
                        Quantity = item.Quantity
                    };
                    _storagesDbContext.ProductStorages.Add(productStorage);
                }
                await _storagesDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException();
            }
        }
    }
}