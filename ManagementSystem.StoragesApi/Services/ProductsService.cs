using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class ProductsService
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<ProductListResponse> GetListProduct(string? searchValue, int? categoryId)
        {
            string[] includes = { "Category" };
            IQueryable<Product> products = _unitOfWork.ProductRepository.GetWithInclude(x => x.Status == ActiveStatus.Active, includes);
            if(searchValue != null && searchValue != String.Empty)
            {
                products = products.Where(x => x.ProductCode.Contains(searchValue) || x.ProductName.Contains(searchValue));
            }
            if(categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }
            var productToList = products.ToList();
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
                    CategoryName = productToList[i].Category.CategoryName,
                    Price = productToList[i].Price,
                    DefaultPurchasePrice = productToList[i].DefaultPurchasePrice,
                };
                listProduct.Add(product);
            }
            return listProduct;
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

                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();

                for(int i = 0; i < request.Units.Count; i++)
                {
                    ProductUnit productUnit = new ProductUnit();
                    productUnit.ProductId = product.ProductId;
                    productUnit.UnitId = request.Units[i].UnitId;
                    productUnit.UnitExchange = request.Units[i].UnitExchange;
                    productUnit.Price = request.Units[i].Price;
                    productUnit.OldPrice = request.Units[i].OldPrice;
                    productUnit.UnitId = request.Units[i].UnitId;
                    productUnit.Barcode = request.Units[i].Barcode;
                    productUnit.IsPrimary = i == 0;
                    _unitOfWork.ProductUnitRepository.Insert(productUnit);
                    _unitOfWork.Save();
                }
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
                        _unitOfWork.Dispose();
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
                        productUnit.OldPrice = request.Units[i].OldPrice;
                        productUnit.UnitId = request.Units[i].UnitId;
                        productUnit.Barcode = request.Units[i].Barcode;
                        productUnit.IsPrimary = i == 0;
                        _unitOfWork.ProductUnitRepository.Insert(productUnit);
                    }
                }
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
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
    }
}
