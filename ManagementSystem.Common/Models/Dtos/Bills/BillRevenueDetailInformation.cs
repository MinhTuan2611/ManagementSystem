namespace ManagementSystem.Common.Models.Dtos;

public class BillRevenueDetailInformation
{
    public int BillId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string UnitName { get; set; }
    public int Quantity { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal Amount { get; set; }

}
