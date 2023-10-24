using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ManagementSystem.StoragesApi.Services
{
    public class ProductsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _storageContext;
        public ProductsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _storageContext = context;
        }

        public List<ProductListResponse> GetListProduct(string? searchValue, int? categoryId, int pageSize, int pageNumber)
        {
            string[] includes = { "Category"};
            IQueryable<Product> products = _unitOfWork.ProductRepository.GetWithInclude(x => x.Status == ActiveStatus.Active, includes);
            if(searchValue != null && searchValue != String.Empty)
            {
                products = products.Where(x => x.ProductCode.Contains(searchValue) || x.ProductName.Contains(searchValue));
            }
            if(categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }
            var productToList = new List<Product>();
            if (pageSize != 0 && pageNumber != 0)
            {
                productToList = products.Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize).ToList();
            } else
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
            return listProduct;
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
                foreach(var item in listProduct)
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
                var units = _unitOfWork.ProductUnitRepository.GetMany(x => x.ProductId == product.ProductId && x.Status == ActiveStatus.Active).OrderBy(x => x.Id).ToList();

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

                for (int i = 0; i < units.Count; i++)
                {
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
                    response.Units.Add(productUnit);
                }
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

                for(int i = 0; i < request.Units.Count; i++)
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
                    productUnit.IsPrimary = i == 0;
                    _unitOfWork.ProductUnitRepository.Insert(productUnit);
                    _unitOfWork.Save();
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
            } catch (Exception ex)
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
                    if(newUnit.IndexOf(productUnit.Id) == -1)
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
                        productUnit.IsPrimary = i == 0;
                        _unitOfWork.ProductUnitRepository.Update(productUnit);
                    } else
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
                        productUnit.IsPrimary = i == 0;
                        _unitOfWork.ProductUnitRepository.Insert(productUnit);
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
                if(product != null)
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

        public ProductDetailInSale? GetProductDetailForSale(string barcode)
        {
            ProductDetailInSale productDetailInSale = new ProductDetailInSale();
            string[] includes = { "Product", "Unit" };
            var productDetail = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.Barcode == barcode && x.Status == ActiveStatus.Active, includes).OrderBy(x => x.Id).FirstOrDefault();
            if(productDetail == null)
            {
                return null;
            }
            string[] unitIncludes = { "Unit" };
            var units = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.ProductId == productDetail.ProductId && x.Status == ActiveStatus.Active, unitIncludes).OrderBy(x => x.Id).ToList();
            var listUnitOfProduct = new List<ProductUnitDetail>();
            foreach (var unit in units)
            {
                ProductUnitDetail productUnit = new ProductUnitDetail();
                productUnit.Id = unit.Id;
                productUnit.ProductId = unit.ProductId;
                productUnit.UnitId = unit.UnitId;
                productUnit.UnitName = unit.Unit?.UnitName;
                productUnit.UnitExchange = unit.UnitExchange;
                productUnit.Price = unit.Price;
                productUnit.OldPrice = unit.OldPrice;
                productUnit.Barcode = unit.Barcode;
                productUnit.IsPrimary = unit.IsPrimary;
                listUnitOfProduct.Add(productUnit);
            }
            var currentUnit = new ProductUnitDetail();
            currentUnit.Id = productDetail.Id;
            currentUnit.ProductId = productDetail.ProductId;
            currentUnit.UnitId = productDetail.UnitId;
            currentUnit.UnitName = productDetail.Unit?.UnitName;
            currentUnit.UnitExchange = productDetail.UnitExchange;
            currentUnit.GrossProfit = productDetail.GrossProfit;
            currentUnit.Price = productDetail.Price;
            currentUnit.OldPrice = productDetail.OldPrice;
            currentUnit.Barcode = productDetail.Barcode;
            currentUnit.IsPrimary = productDetail.IsPrimary;

            productDetailInSale.Id = productDetail.ProductId;
            productDetailInSale.Barcode = productDetail.Barcode ?? string.Empty;
            productDetailInSale.Name = productDetail.Product?.ProductName ?? string.Empty;
            productDetailInSale.Unit = currentUnit;
            productDetailInSale.Price = productDetail.Price;
            productDetailInSale.ProductUnits = listUnitOfProduct;
            return productDetailInSale;
        }

        public List<ProductDetailInSale>? AutoCompleteGetProductDetailForSale(string barcode)
        {
            List<ProductDetailInSale> productDetailInSales = new List<ProductDetailInSale>();
            string[] includes = { "Product", "Unit" };
            List<ProductUnit> productDetails = _unitOfWork.ProductUnitRepository.GetWithInclude(x => (x.Barcode.Contains(barcode) || x.Product.ProductName.Contains(barcode)) && x.Status == ActiveStatus.Active, includes).OrderBy(x => x.Id).ToList();
            if (productDetails == null)
            {
                return null;
            }
            string[] unitIncludes = { "Unit" };
            foreach(ProductUnit productDetail in productDetails)
            {
                ProductDetailInSale productDetailInSale = new ProductDetailInSale();
                var units = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.ProductId == productDetail.ProductId && x.Status == ActiveStatus.Active, unitIncludes).OrderBy(x => x.Id).ToList();
                var listUnitOfProduct = new List<ProductUnitDetail>();
                foreach (var unit in units)
                {
                    ProductUnitDetail productUnit = new ProductUnitDetail();
                    productUnit.Id = unit.Id;
                    productUnit.ProductId = unit.ProductId;
                    productUnit.UnitId = unit.UnitId;
                    productUnit.UnitName = unit.Unit?.UnitName;
                    productUnit.UnitExchange = unit.UnitExchange;
                    productUnit.Price = unit.Price;
                    productUnit.OldPrice = unit.OldPrice;
                    productUnit.Barcode = unit.Barcode;
                    productUnit.IsPrimary = unit.IsPrimary;
                    listUnitOfProduct.Add(productUnit);
                }
                var currentUnit = new ProductUnitDetail();
                currentUnit.Id = productDetail.Id;
                currentUnit.ProductId = productDetail.ProductId;
                currentUnit.UnitId = productDetail.UnitId;
                currentUnit.UnitName = productDetail.Unit?.UnitName;
                currentUnit.UnitExchange = productDetail.UnitExchange;
                currentUnit.Price = productDetail.Price;
                currentUnit.OldPrice = productDetail.OldPrice;
                currentUnit.Barcode = productDetail.Barcode;
                currentUnit.IsPrimary = productDetail.IsPrimary;

                productDetailInSale.Id = productDetail.ProductId;
                productDetailInSale.Barcode = productDetail.Barcode ?? string.Empty;
                productDetailInSale.Name = productDetail.Product?.ProductName ?? string.Empty;
                productDetailInSale.Unit = currentUnit;
                productDetailInSale.Price = productDetail.Price;
                productDetailInSale.ProductUnits = listUnitOfProduct;

                productDetailInSales.Add(productDetailInSale);
            }
            
            return productDetailInSales;
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
                ",items);

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
        // private function check part name is in product name
        private bool CheckAnimalPartInProductName(string productName, List<string> AniamlPartSplit)
        {
            foreach (var part in AniamlPartSplit)
            if (productName.ToLower().Contains(part.ToLower()))
                return true;
            return false;
                
        }
    }
}
