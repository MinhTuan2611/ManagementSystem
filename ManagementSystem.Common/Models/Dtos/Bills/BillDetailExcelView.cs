namespace ManagementSystem.Common.Models.Dtos.Bills
{
    public class BillDetailExcelView
    {
        public int BillId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public int Amount { get; set; }
    }
}
