namespace ManagementSystem.Common.Models.Dtos;

public class BillRevenueDetailInformation
{
    public int BillId { get; set; }
    public string BranchCode { get; set; }
    public string BranchName { get; set; }
    public DateTime CreateDate { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string UnitName { get; set; }
    public float Quantity { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal Amount { get; set; }

}
