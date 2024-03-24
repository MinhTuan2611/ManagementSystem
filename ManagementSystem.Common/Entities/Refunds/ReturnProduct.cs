using ManagementSystem.Common.Models.Enum;

namespace ManagementSystem.Common.Entities;

public class ReturnProduct
{
    public int ExchangeItemVoucherId { get; set; }
    public RefundAction Action { get; set; }
    public int ProductId { get; set; }
    public float Quantity { get; set; }
    public float Price { get; set; }
    public RefundReason ReasonRef { get; set; }
}
