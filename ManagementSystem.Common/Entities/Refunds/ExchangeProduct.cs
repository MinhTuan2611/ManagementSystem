namespace ManagementSystem.Common.Entities;

public class ExchangeProduct
{
    public int ExchangeItemVoucherId { get; set; }
    public int ProductId { get; set; }
    public float Quantity { get; set; }
    public float Price { get; set; }
    public int UnitId { get; set; }
}
