namespace ManagementSystem.Common.Models.Dtos
{
    public class InventoryVoucherDetailDto
    {
        public int DocummentNumber { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public int UnitId { get; set; }
        public int TotalMoneyAfterTax { get; set; }
        public string Note { get; set; } = "";
    }
}
