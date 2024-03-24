using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Text;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models.Dtos.Products;
using ManagementSystem.Common.Helpers;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Azure.Core;

namespace ManagementSystem.StoragesApi.Services
{
    public class ProductsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _storageContext;
        private readonly string _import_file_location;
        public ProductsService(StoragesDbContext context, IConfiguration configuration)
        {
            _unitOfWork = new UnitOfWork(context);
            _storageContext = context;
            _import_file_location = configuration.GetValue<string>("Import_File_Location");
        }

        public async Task<(List<ProductListResponse>, int)> GetListProduct(string? searchValue, int? categoryId, int pageSize, int pageNumber)
        {
            string[] includes = { "Category" };
            IQueryable<Product> products = _unitOfWork.ProductRepository.GetWithInclude(x => x.Status == ActiveStatus.Active, includes);
            var totalRecord = 0;
            if (searchValue != null && searchValue != String.Empty)
            {
                products = products.Where(x => x.ProductCode.Contains(searchValue) || x.ProductName.Contains(searchValue));
            }
            if (categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }
            var productToList = new List<Product>();
            totalRecord = await products.CountAsync();
            if (pageSize != 0 && pageNumber != 0)
            {
                productToList = products.Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize).ToList();
            }
            else
            {
                productToList = products.ToList();
            }
            var listProduct = new List<ProductListResponse>();
            for (int i = 0; i < productToList.Count; i++)
            {
                var product = new ProductListResponse
                {
                    ProductId = productToList[i].ProductId,
                    ProductName = productToList[i].ProductName,
                    ProductCode = productToList[i].ProductCode,
                    BarCode = productToList[i].BarCode,
                    CategoryId = productToList[i].CategoryId,
                    CategoryName = productToList[i].Category?.CategoryName,
                    Price = productToList[i].Price,
                    DefaultPurchasePrice = productToList[i].DefaultPurchasePrice,
                };
                listProduct.Add(product);
            }
            return (listProduct, totalRecord);
        }

        public IEnumerable<ProductInfo> AutoCompleteProduct(string? valueSearch)
        {
            string[] includes = { "Product", "Unit" };
            if (valueSearch == null)
            {
                return new List<ProductInfo>();
            }
            List<ProductUnit> listProduct = _unitOfWork.ProductUnitRepository.GetWithInclude(s => (s.Product.ProductName.ToLower().Contains(valueSearch.Trim().ToLower())
           || s.Barcode.ToLower().Contains(valueSearch.Trim().ToLower())), includes).ToList();
            if (listProduct.Any())
            {
                List<ProductInfo> result = new List<ProductInfo>();
                foreach (var item in listProduct)
                {
                    result.Add(new ProductInfo
                    {
                        ProductCode = item.Product.ProductCode,
                        BarCode = item.Barcode,
                        Price = item.Price,
                        DefaultPurchasePrice = item.Product.DefaultPurchasePrice,
                        ProductName = item.Product.ProductName,
                        Tax = item.Product.Tax,
                        Unit = item.Unit.UnitName
                    });
                }
                return result;
            }
            return new List<ProductInfo>();
        }

        public ProductCreateUpdate GetProductDetail(int productId)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                var productSupliersRes = _unitOfWork.ProductSupplierRepository.GetMany(x => x.ProductId == productId);
                var units = _unitOfWork.ProductUnitRepository.GetMany(x => x.ProductId == product.ProductId && x.Status == ActiveStatus.Active).OrderBy(x => x.Id).ToList();
                var productUnitBranchs = _unitOfWork.ProductUnitBranchRepository.Get().ToList();

                List<ProductSupplierDto> productSupliers = new List<ProductSupplierDto>();

                foreach (var productSuplier in productSupliersRes)
                {
                    productSupliers.Add(new ProductSupplierDto { SupplierId = productSuplier.SupplierId });
                }

                ProductCreateUpdate response = new ProductCreateUpdate();
                response.ProductId = product.ProductId;
                response.ProductName = product.ProductName;
                response.ProductCode = product.ProductCode;
                response.CategoryId = product.CategoryId;
                response.DefaultPurchasePrice = product.DefaultPurchasePrice;
                response.Tax = product.Tax;
                response.Price = product.Price;
                response.Status = product.Status;
                response.Units = new List<ProductUnitDetail>();
                response.ProductSuppliers = productSupliers;

                for (int i = 0; i < units.Count; i++)
                {

                    List<ProductUnitBranch> unitBranchs = productUnitBranchs.Where(x => x.ProductUnitId == units[i].Id).ToList();
                    // GetProductUnitBranch(units[i].Id, 0);

                    if (unitBranchs.Count > 0)
                    {
                        foreach (var unitBranch in unitBranchs)
                        {
                            ProductUnitDetail productUnitBranch = new ProductUnitDetail();
                            productUnitBranch.Id = units[i].Id;
                            productUnitBranch.ProductId = units[i].ProductId;
                            productUnitBranch.UnitId = units[i].UnitId;
                            productUnitBranch.UnitExchange = units[i].UnitExchange;
                            productUnitBranch.Price = unitBranch != null ? (int)unitBranch.Price : units[i].Price;
                            productUnitBranch.GrossProfit = units[i].GrossProfit;
                            productUnitBranch.OldPrice = units[i].OldPrice;
                            productUnitBranch.Barcode = units[i].Barcode;
                            productUnitBranch.IsPrimary = units[i].IsPrimary;
                            productUnitBranch.BranchId = unitBranch?.BranchId ?? 0;
                            response.UnitsBranch.Add(productUnitBranch);
                        }
                    }

                    ProductUnitDetail productUnit = new ProductUnitDetail();
                    productUnit.Id = units[i].Id;
                    productUnit.ProductId = units[i].ProductId;
                    productUnit.UnitId = units[i].UnitId;
                    productUnit.UnitExchange = units[i].UnitExchange;
                    productUnit.Price = units[i].Price;
                    productUnit.GrossProfit = units[i].GrossProfit;
                    productUnit.OldPrice = units[i].OldPrice;
                    productUnit.Barcode = units[i].Barcode;
                    productUnit.IsPrimary = units[i].IsPrimary;
                    productUnit.BranchId = 0;
                    response.Units.Add(productUnit);
                }
                response.UnitDictionary = response.UnitsBranch.GroupBy(x => x.BranchId)
                                            .ToDictionary(k => k.Key, k => k.ToList());
                response.Units = response.Units.DistinctBy(x => x.Id).ToList();

                response.UnitsBranch = null;
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CreateProduct(ProductCreateUpdate request)
        {
            try
            {
                Product product = new Product();
                product.ProductName = request.ProductName;
                product.ProductCode = request.ProductCode;
                product.CategoryId = request.CategoryId;
                product.DefaultPurchasePrice = request.DefaultPurchasePrice;
                product.Tax = request.Tax;
                product.Price = request.Units[0].Price;
                product.BarCode = request.Units[0].Barcode;
                product.CreditAccountId = request.CreditAccountId;
                product.DebitAccountId = request.DebitAccountId;
                product.RevenueGroupId = request.RevenueGroupId;

                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();

                for (int i = 0; i < request.Units.Count; i++)
                {
                    ProductUnit productUnit = new ProductUnit();
                    productUnit.ProductId = product.ProductId;
                    productUnit.UnitId = request.Units[i].UnitId;
                    productUnit.UnitExchange = request.Units[i].UnitExchange;
                    productUnit.Price = request.Units[i].Price;
                    productUnit.GrossProfit = request.Units[i].GrossProfit;
                    productUnit.OldPrice = request.Units[i].OldPrice;
                    productUnit.UnitId = request.Units[i].UnitId;
                    productUnit.Barcode = request.Units[i].Barcode;
                    productUnit.IsPrimary = request.Units[i].IsPrimary;
                    _unitOfWork.ProductUnitRepository.Insert(productUnit);
                    _unitOfWork.Save();

                    if (request.Units[i].BranchId > 0)
                    {
                        var productUnitBrach = new ProductUnitBranch()
                        {
                            ProductUnitId = productUnit.Id,
                            BranchId = request.Units[i].BranchId,
                            Price = request.Units[i].Price,
                            CreateBy = request.ModifyBy,
                            ModifyBy = request.ModifyBy,
                        };

                        _storageContext.ProductUnitBranches.Add(productUnitBrach);
                        _storageContext.SaveChanges();
                    }
                }

                // Add Product Supplier
                foreach (var item in request.ProductSuppliers)
                {
                    var supplier = new ProductSupplier()
                    {
                        ProductId = product.ProductId,
                        SupplierId = item.SupplierId,
                        CreateBy = request.ModifyBy,
                        ModifyBy = request.ModifyBy,
                    };

                    _unitOfWork.ProductSupplierRepository.Insert(supplier);
                    _unitOfWork.Save();
                }


                // Add activity logs
                _storageContext.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.ModifyBy.Value,
                    Action = "Create Product: " + product.ProductId.ToString(),
                    Source = "Product",
                    DateModified = DateTime.Now,
                });

                _storageContext.SaveChanges();

                _unitOfWork.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateProduct(ProductCreateUpdate request)
        {
            try
            {
                Product product = new Product();
                product.ProductId = request.ProductId;
                product.ProductName = request.ProductName;
                product.ProductCode = request.ProductCode;
                product.CategoryId = request.CategoryId;
                product.DefaultPurchasePrice = request.DefaultPurchasePrice;
                product.Tax = request.Tax;
                product.Price = request.Units[0].Price;
                product.BarCode = request.Units[0].Barcode;
                product.CreditAccountId = request.CreditAccountId;
                product.DebitAccountId = request.DebitAccountId;
                product.RevenueGroupId = request.RevenueGroupId;
                product.ModifyBy = request.ModifyBy;

                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();

                var currentUnit = _unitOfWork.ProductUnitRepository.GetMany(x => x.ProductId == product.ProductId && x.Status == ActiveStatus.Active).ToList();
                var newUnit = request.Units.Where(x => x.Id != null).Select(x => x.Id).ToList();
                foreach (ProductUnit productUnit in currentUnit)
                {
                    if (newUnit.IndexOf(productUnit.Id) == -1)
                    {
                        productUnit.Status = ActiveStatus.Inactive;
                        _unitOfWork.ProductUnitRepository.Update(productUnit);
                        _unitOfWork.Save();
                    }
                }

                for (int i = 0; i < request.Units.Count; i++)
                {
                    if (request.Units[i].Id != null)
                    {
                        ProductUnit productUnit = currentUnit.Where(x => x.Id == request.Units[i].Id).First();
                        productUnit.ProductId = product.ProductId;
                        productUnit.UnitId = request.Units[i].UnitId;
                        productUnit.UnitExchange = request.Units[i].UnitExchange;
                        productUnit.Price = request.Units[i].Price;
                        productUnit.GrossProfit = request.Units[i].GrossProfit;
                        productUnit.OldPrice = request.Units[i].OldPrice;
                        productUnit.UnitId = request.Units[i].UnitId;
                        productUnit.Barcode = request.Units[i].Barcode;
                        productUnit.IsPrimary = request.Units[i].IsPrimary;
                        _unitOfWork.ProductUnitRepository.Update(productUnit);

                    }
                    else
                    {
                        ProductUnit productUnit = new ProductUnit();
                        productUnit.ProductId = product.ProductId;
                        productUnit.UnitId = request.Units[i].UnitId;
                        productUnit.UnitExchange = request.Units[i].UnitExchange;
                        productUnit.Price = request.Units[i].Price;
                        productUnit.GrossProfit = request.Units[i].GrossProfit;
                        productUnit.OldPrice = request.Units[i].OldPrice;
                        productUnit.UnitId = request.Units[i].UnitId;
                        productUnit.Barcode = request.Units[i].Barcode;
                        productUnit.IsPrimary = request.Units[i].IsPrimary;
                        _unitOfWork.ProductUnitRepository.Insert(productUnit);
                    }
                }


                foreach (var entry in request.UnitDictionary)
                {
                    int branchId = entry.Key;
                    List<ProductUnitDetail> productUnitDetails = entry.Value;

                    foreach (var item in productUnitDetails)
                    {
                        var productUnitBranch = _storageContext.ProductUnitBranches.FirstOrDefault(x => x.BranchId == branchId && x.ProductUnitId == item.Id);

                        if (productUnitBranch != null && item.Price != productUnitBranch.Price)
                        {
                            productUnitBranch.Price = item.Price;
                            productUnitBranch.ModifyDate = DateTime.Now;

                            _storageContext.SaveChanges();
                        }
                        else if (productUnitBranch == null)
                        {
                            productUnitBranch = new ProductUnitBranch()
                            {
                                ProductUnitId = item.Id.Value,
                                BranchId = branchId,
                                Price = item.Price,
                                CreateBy = request.ModifyBy,
                                ModifyBy = request.ModifyBy
                            };

                            _storageContext.ProductUnitBranches.Add(productUnitBranch);
                            _storageContext.SaveChanges();
                        }
                    }
                }

                _unitOfWork.Save();

                // Update Supplier
                var suppiers = _storageContext.ProductSuppliers.Where(x => x.ProductId == product.ProductId).ToList();

                _storageContext.ProductSuppliers.RemoveRange(suppiers);

                // Add Product Supplier
                List<ProductSupplier> suppliers = new List<ProductSupplier>();
                foreach (var item in request.ProductSuppliers)
                {
                    var supplier = new ProductSupplier()
                    {
                        ProductId = request.ProductId,
                        SupplierId = item.SupplierId,
                        CreateBy = request.ModifyBy,
                        ModifyBy = request.ModifyBy,
                    };

                    _storageContext.ProductSuppliers.Add(supplier);
                }
                // Add activity logs
                _storageContext.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.ModifyBy.Value,
                    Action = "Update Product: " + product.ProductId.ToString(),
                    Source = "Product",
                    DateModified = DateTime.Now,
                });

                _storageContext.SaveChanges();
                _unitOfWork.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProduct(int productId, int? userId)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                if (product != null)
                {
                    product.Status = ActiveStatus.Inactive;
                    product.ModifyBy = userId;
                    _unitOfWork.ProductRepository.Update(product);
                    _unitOfWork.Save();
                    _unitOfWork.Dispose();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public ProductDetailInSale? GetProductDetailForSale(string barcode, int branchId = 3)
        {
            ProductDetailInSale productDetailInSale = new ProductDetailInSale();
            string[] includes = { "Product", "Unit" };
            var productDetail = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.Barcode == barcode && x.Status == ActiveStatus.Active, includes).OrderByDescending(x => x.IsPrimary).FirstOrDefault();
            var productUnitBranchs = _unitOfWork.ProductUnitBranchRepository.Get().ToList();

            if (productDetail == null)
            {
                return null;
            }
            string[] unitIncludes = { "Unit" };
            var units = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.ProductId == productDetail.ProductId && x.Status == ActiveStatus.Active, unitIncludes).OrderBy(x => x.Id).ToList();
            var listUnitOfProduct = new List<ProductUnitDetail>();
            foreach (var unit in units)
            {
                ProductUnitDetail productUnit = new ProductUnitDetail();
                ProductUnitBranch unitBranchdetail = productUnitBranchs.FirstOrDefault(x => (x.ProductUnitId == unit.Id && x.BranchId == branchId));

                productUnit.Id = unit.Id;
                productUnit.ProductId = unit.ProductId;
                productUnit.UnitId = unit.UnitId;
                productUnit.UnitName = unit.Unit?.UnitName;
                productUnit.UnitExchange = unit.UnitExchange;
                productUnit.Price = unitBranchdetail != null ? (int)unitBranchdetail.Price : unit.Price;
                productUnit.OldPrice = unit.OldPrice;
                productUnit.Barcode = unit.Barcode;
                productUnit.IsPrimary = unit.IsPrimary;
                productUnit.GrossProfit = unit.GrossProfit;
                listUnitOfProduct.Add(productUnit);
            }
            var currentUnit = new ProductUnitDetail();
            ProductUnitBranch unitBranch = productUnitBranchs.FirstOrDefault(x => (x.ProductUnitId == productDetail.Id && x.BranchId == branchId));

            currentUnit.Id = productDetail.Id;
            currentUnit.ProductId = productDetail.ProductId;
            currentUnit.UnitId = productDetail.UnitId;
            currentUnit.UnitName = productDetail.Unit?.UnitName;
            currentUnit.UnitExchange = productDetail.UnitExchange;
            currentUnit.GrossProfit = productDetail.GrossProfit;
            currentUnit.Price = unitBranch != null ? (int)unitBranch.Price : productDetail.Price;
            currentUnit.OldPrice = productDetail.OldPrice;
            currentUnit.Barcode = productDetail.Barcode;
            currentUnit.IsPrimary = productDetail.IsPrimary;

            productDetailInSale.Id = productDetail.ProductId;
            productDetailInSale.Barcode = productDetail.Barcode ?? string.Empty;
            productDetailInSale.Name = productDetail.Product?.ProductName ?? string.Empty;
            productDetailInSale.Unit = currentUnit;
            productDetailInSale.Price = unitBranch != null ? (int)unitBranch.Price : productDetail.Price;
            productDetailInSale.ProductUnits = listUnitOfProduct;
            return productDetailInSale;
        }

        public TPagination<ProductDetailInSale>? AutoCompleteGetProductDetailForSale(string barcode, int pageNumber, int pageSize, int branchId = 3)
        {
            List<ProductDetailInSale> productDetailInSales = new List<ProductDetailInSale>();

            var result = new TPagination<ProductDetailInSale>();

            //barcode = convertToUnSign(barcode);
            var valueSearch = barcode.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] includes = { "Product", "Unit" };
            List<ProductUnit> productDetails = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.Status == ActiveStatus.Active, includes).AsNoTracking().ToList();
            var productDetailsFilter = productDetails.Where(x => x.Barcode == barcode || valueSearch.All(keyWord => x.Product.ProductName.ToLower().Contains(keyWord)
                                                                                                        || x.Product.ProductCode.ToLower().Contains(keyWord)
                                                                                                        || x.Unit.UnitName.ToLower().Contains(keyWord))).ToList();
            result.TotalItems = productDetailsFilter.Count;

            productDetailsFilter = productDetailsFilter.OrderBy(x => x.Id)
                                                        .Skip((pageNumber - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToList();

            var productUnitBranchs = _unitOfWork.ProductUnitBranchRepository.Get().ToList();

            if (productDetailsFilter == null)
            {
                return null;
            }
            string[] unitIncludes = { "Unit" };
            foreach (ProductUnit productDetail in productDetailsFilter)
            {
                ProductDetailInSale productDetailInSale = new ProductDetailInSale();

                var units = productDetails.Where(x => x.ProductId == productDetail.ProductId).ToList();
                var listUnitOfProduct = new List<ProductUnitDetail>();
                foreach (var unit in units)
                {
                    ProductUnitDetail productUnit = new ProductUnitDetail();
                    ProductUnitBranch unitBranchdetail = productUnitBranchs.FirstOrDefault(x => (x.ProductUnitId == unit.Id && x.BranchId == branchId));

                    productUnit.Id = unit.Id;
                    productUnit.ProductId = unit.ProductId;
                    productUnit.UnitId = unit.UnitId;
                    productUnit.UnitName = unit.Unit?.UnitName;
                    productUnit.UnitExchange = unit.UnitExchange;
                    productUnit.Price = unitBranchdetail != null ? (int)unitBranchdetail.Price : unit.Price;
                    productUnit.OldPrice = unit.OldPrice;
                    productUnit.Barcode = unit.Barcode;
                    productUnit.IsPrimary = unit.IsPrimary;
                    listUnitOfProduct.Add(productUnit);
                }
                var currentUnit = new ProductUnitDetail();
                ProductUnitBranch unitBranch = productUnitBranchs.FirstOrDefault(x => (x.ProductUnitId == productDetail.Id && x.BranchId == branchId));

                currentUnit.Id = productDetail.Id;
                currentUnit.ProductId = productDetail.ProductId;
                currentUnit.UnitId = productDetail.UnitId;
                currentUnit.UnitName = productDetail.Unit?.UnitName;
                currentUnit.UnitExchange = productDetail.UnitExchange;
                currentUnit.Price = unitBranch != null ? (int)unitBranch.Price : productDetail.Price;
                currentUnit.OldPrice = productDetail.OldPrice;
                currentUnit.Barcode = productDetail.Barcode;
                currentUnit.IsPrimary = productDetail.IsPrimary;

                productDetailInSale.Id = productDetail.ProductId;
                productDetailInSale.Barcode = productDetail.Barcode ?? string.Empty;
                productDetailInSale.Name = productDetail.Product?.ProductName ?? string.Empty;
                productDetailInSale.Unit = currentUnit;
                productDetailInSale.Price = unitBranch != null ? (int)unitBranch.Price : productDetail.Price;
                productDetailInSale.ProductUnits = listUnitOfProduct;

                productDetailInSales.Add(productDetailInSale);
            }

            result.Items = productDetailInSales;
            return result;
        }

        public string GenerateProductCode(int categoryId, string productName)
        {
            string categoryRefCode = _unitOfWork.CategoryRepository.Get(x => x.CategoryId == categoryId)?.CategoryRefCode.ToString();
            string animalPartRefCode = _unitOfWork.AnimalPartRefCodeRepository.Get(x =>
                    CheckAnimalPartInProductName(productName, x.PartName.Split("/").ToList()))?.RefCode.ToString(); // Handle some part like Nọng/má

            //// check category is valid
            if (string.IsNullOrEmpty(categoryRefCode) || string.IsNullOrEmpty(animalPartRefCode))
                return "";

            // Add 0 to the left if the code < 5
            categoryRefCode = categoryRefCode.PadLeft(5, '0');
            return string.Format("{0}{1}", categoryRefCode, animalPartRefCode);
        }

        public List<ProductAutoGenerationResponseDto> AutoRandomProducts(int items, int? brandId)
        {

            string query = string.Format(@"
                SELECT TOP {0} P.ProductId
	                  ,p.ProductCode
	                  ,p.ProductName
	                  ,u.UnitId
	                  ,u.UnitName
	                  ,ps.Quantity AS TotalSystemAmount
                FROM dbo.Products p
                JOIN dbo.ProductUnit pu  ON pu.ProductId = p.ProductId
                JOIN dbo.Unit u ON u.UnitId = pu.UnitId
                LEFT JOIN dbo.ProductStorages ps ON ps.ProductId = p.ProductId
                LEFT JOIN dbo.Storages s ON s.StorageId = ps.StorageId
                LEFT JOIN dbo.Branches b ON b.BranchId = s.BranchId
                ORDER BY NEWID()
                ", items);

            try
            {
                var result = _storageContext.ProductAutoGenerationResponseDtos.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<ProductUnitBranchResponseDto> GetProductUnitBranch(int unitId, int branchId)
        {
            string query = string.Empty;

            if (branchId > 0)
            {
                query = string.Format(@"
                    SELECT ProductUnitId
		                    ,BranchId
		                    ,Price
                    FROM [dbo].[ProductUnitBranches]
                    WHERE ProductUnitId = {0}
                        AND BranchId = {1}
                ", unitId, branchId);
            }
            else
            {
                query = string.Format(@"
                    SELECT ProductUnitId
		                    ,BranchId
		                    ,Price
                    FROM [dbo].[ProductUnitBranches]
                    WHERE ProductUnitId = {0}
                ", unitId);
            }

            try
            {

                var result = _storageContext.ProductUnitBranchResponseDtos.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ProductDetailResponseDto ProductDetailByIdAndUnit(int productId, int unitId)
        {

            string query = string.Format(@"
                    SELECT p.ProductId
		                    ,p.ProductCode
                            ,p.ProductName
                            ,CONVERT(DECIMAL(18, 2), p.Price) AS Price
		                    ,CONVERT(DECIMAL(18, 2), p.DefaultPurchasePrice) AS DefaultPurchasePrice
		                    ,p.BarCode
		                    ,p.Tax
		                    ,c.CategoryName
		                    ,u.UnitName
                    FROM dbo.Products p
                    JOIN dbo.Category c ON c.CategoryId = p.CategoryId
                    JOIN dbo.ProductUnit pu ON pu.ProductId = p.ProductId
                    JOIN dbo.Unit U ON U.UnitId = pu.UnitId
                    WHERE p.ProductId = {0} AND U.UnitId = {1}
                ", productId, unitId);

            try
            {
                var result = _storageContext.ProductResponseDtos.FromSqlRaw(query).SingleOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // private function check part name is in product name
        private bool CheckAnimalPartInProductName(string productName, List<string> AniamlPartSplit)
        {
            foreach (var part in AniamlPartSplit)
                if (productName.ToLower().Contains(part.ToLower()))
                    return true;
            return false;

        }

        private static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
        }

        private string UploadExcelFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null.", nameof(file));
            }

            // Ensure the directory exists
            if (!Directory.Exists(_import_file_location))
            {
                Directory.CreateDirectory(_import_file_location);
            }

            var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_import_file_location, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }

        public List<ProductReviewImportDto> ReviewImportProduct(IFormFile file)
        {
            try
            {
                var filePath = UploadExcelFile(file);
                if (Path.GetExtension(filePath).Equals(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    string convertedFilePath = Path.ChangeExtension(filePath, ".xlsx");
                    ExcelImportHelper.ConvertXlsToXlsx(filePath, convertedFilePath);
                    filePath = convertedFilePath; // Use the converted file
                }
                var excelData = ReadExcelFile(filePath);
                var result = ReviewImportFile(excelData);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ImportProduct(List<ProductImportRequest> listImport, int userId)
        {
            try
            {
                foreach (var item in listImport)
                {
                    if (item.status == ImportProductStatus.UpdateProduct.ToString())
                    {
                        var product = _storageContext.Products.FirstOrDefault(x => x.ProductCode == item.ProductCode);
                        if (product == null) return false;

                        product.ProductName = item.ProductName;
                        product.DefaultPurchasePrice = item.DefaultPurchasePrice;
                        product.Price = item.Price;
                        product.ModifyBy = userId;
                        _unitOfWork.ProductRepository.Update(product);
                    }
                    if (item.status == ImportProductStatus.CreateProduct.ToString())
                    {
                        var product = new Product();
                        product.ProductCode = item.ProductCode;
                        product.ProductName = item.ProductName;
                        product.DefaultPurchasePrice = item.DefaultPurchasePrice;
                        product.Price = item.Price;
                        product.CategoryId = item.CategoryId;
                        product.ModifyBy = userId;
                        _unitOfWork.ProductRepository.Insert(product);
                        _unitOfWork.Save();
                        if (item.UnitId != null)
                        {
                            ProductUnit productUnit = new ProductUnit();
                            productUnit.ProductId = product.ProductId;
                            productUnit.UnitId = item.UnitId.Value;
                            productUnit.IsPrimary = true;
                            productUnit.UnitExchange = 1;
                            _unitOfWork.ProductUnitRepository.Insert(productUnit);
                        }
                    }
                }
                _unitOfWork.Save();
                _unitOfWork.Dispose();

                // Add activity logs
                _storageContext.ActivityLog.Add(new ActivityLog()
                {
                    UserId = userId,
                    Action = "Import Products",
                    Source = "Product",
                    DateModified = DateTime.Now,
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private List<ProductReviewImport> ReadExcelFile(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context
            List<ProductReviewImport> productReviews = new List<ProductReviewImport>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var workbook = package.Workbook;
                if (workbook != null && workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet worksheet = null;
                    foreach (var sheet in workbook.Worksheets)
                    {
                        if (sheet.Hidden == eWorkSheetHidden.Visible)
                        {
                            worksheet = sheet;
                            break;
                        }
                    }
                    for (int row = 2; row <= worksheet?.Dimension.End.Row; row++)
                    {
                        var productReviewImport = new ProductReviewImport
                        {
                            ProductCode = worksheet.Cells[row, 3].Text,
                            ProductName = worksheet.Cells[row, 4].Text,
                            CategoryId = int.TryParse(worksheet.Cells[row, 6].Text, out int categoryId) ? categoryId : null,
                            UnitName = worksheet.Cells[row, 7].Text,
                            DefaultPurchasePrice = int.TryParse(worksheet.Cells[row, 8].Text.Replace(",", ""), out int defaultPurchasePrice) ? defaultPurchasePrice : 0,
                            Price = int.TryParse(worksheet.Cells[row, 9].Text.Replace(",", ""), out int price) ? price : 0
                        };
                        if (productReviewImport.ProductCode.IsNullOrEmpty() == false)
                        {
                            productReviews.Add(productReviewImport);
                        }
                    }
                }
                return productReviews;
            }
        }

        private List<ProductReviewImportDto> ReviewImportFile(List<ProductReviewImport> file)
        {
            var productReviewDto = new List<ProductReviewImportDto>();
            foreach (var item in file)
            {
                var importProduct = new ProductReviewImportDto();

                var product = _storageContext.Products.FirstOrDefault(x => x.ProductCode == item.ProductCode);
                importProduct.ProductCode = item.ProductCode;
                importProduct.ProductName = item.ProductName;
                importProduct.DefaultPurchasePrice = item.DefaultPurchasePrice;
                importProduct.Price = item.Price;
                importProduct.UnitName = item.UnitName;
                importProduct.CategoryId = product?.CategoryId;


                if (product != null)
                {
                    var productUnit = _storageContext.ProductUnit.Include(x => x.Unit).FirstOrDefault(x => x.ProductId == product.ProductId);
                    if (productUnit != null)
                    {
                        importProduct.UnitName = productUnit.Unit.UnitName;
                        importProduct.UnitId = productUnit.Unit.UnitId;
                    }


                    var productCategory = _storageContext.Category.FirstOrDefault(x => x.CategoryId == item.CategoryId);
                    if (productCategory != null)
                    {
                        importProduct.CategoryName = productCategory.CategoryName;
                    }
                    if (product.ProductName != item.ProductName || product.DefaultPurchasePrice != item.DefaultPurchasePrice || product.Price != item.Price)
                    {
                        importProduct.status = ImportProductStatus.UpdateProduct.ToString();
                    }
                }
                else
                {
                    if (item.UnitName.IsNullOrEmpty() == false)
                    {
                        var unit = _storageContext.Unit.FirstOrDefault(x => x.UnitName == item.UnitName);
                        importProduct.UnitId = unit?.UnitId;
                    }
                    importProduct.status = ImportProductStatus.CreateProduct.ToString();
                }
                productReviewDto.Add(importProduct);
            }
            return productReviewDto;
        }
    }
}
