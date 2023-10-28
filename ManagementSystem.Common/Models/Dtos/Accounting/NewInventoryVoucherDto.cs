namespace ManagementSystem.Common.Models.Dtos
{
    public class NewInventoryVoucherDto
    {
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeShiftId { get; set; }
        public int? BrandId { get; set; } = 1;
        public int? BillId { get; set; }
        public string PurchasingRepresentive { get; set; }
        public string Note { get; set; } = "";
        public int CashPaymentAmount { get; set; }
        public List<InventoryVoucherDetailDto> Details { get; set; }
    }
}
