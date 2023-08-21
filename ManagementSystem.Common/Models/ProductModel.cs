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
}
