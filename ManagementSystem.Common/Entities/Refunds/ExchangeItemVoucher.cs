using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities;

public class ExchangeItemVoucher
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? CustomerId { get; set; }
    public float RefundAmount { get; set; } = 0;
    public int TotalExchangeProduct { get; set; }
    public int TotalReturnProduct { get; set; }
    public int? BranchId { get; set; }
}
