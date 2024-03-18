namespace ManagementSystem.Common.Models.Dtos
{
    public class NewReceiptRequestDto
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string ForReason { get; set; }
        public float TotalMoney { get; set; }
        public int UserId { get; set; }
        public int? BillId { get; set; }
        public int InventoryDocumentNumber { get; set; } = 0;
        public int? StorageId { get; set; }
    }
}
