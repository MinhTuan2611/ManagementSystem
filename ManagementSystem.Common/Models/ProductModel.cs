using ManagementSystem.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Models
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string? BarCode { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int Price { get; set; }
        public int? Tax { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public int DefaultPurchasePrice { get; set; }
    }
    public class ProductListResponse
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string? BarCode { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int Price { get; set; }
        public int? Tax { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public int DefaultPurchasePrice { get; set; }

    }
    public class ProductCreateUpdate
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string? BarCode { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int Price { get; set; }
        public int? Tax { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public int DefaultPurchasePrice { get; set; }
        public List<ProductUnitDetail> Units { get; set; }
        public int? ModifyBy { get; set; }
    }
    public class ProductUnitDetail
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public string? UnitName { get; set; }
        public int UnitExchange { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; } = 0;
        public bool IsPrimary { get; set; }
        public string? Barcode { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }

    public class ProductDetailInSale
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public ProductUnitDetail Unit { get; set; }
        public int Price { get; set; }
        public int? Promotion { get; set; }
        public int? Quantity { get; set; }
        public int? Amount { get; set; }
        public List<ProductUnitDetail> ProductUnits { get; set; }
    }
}
