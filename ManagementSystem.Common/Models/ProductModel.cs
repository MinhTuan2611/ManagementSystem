namespace ManagementSystem.Common.Models
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int DefaultSalePrice { get; set; }
        public int DefaultPurchasePrice { get; set; }
        public int UnitId { get; set; }
    }
}
