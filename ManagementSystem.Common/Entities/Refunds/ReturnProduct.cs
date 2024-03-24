namespace ManagementSystem.Common.Entities;

public class ReturnProduct
{
    public int ExchangeItemVoucherId { get; set; }
    public int Action { get; set; }
    public int ProductId { get; set; }
    public float Quantity { get; set; }
    public float Price { get; set; }
    public int ReasonRef { get; set; }
}
