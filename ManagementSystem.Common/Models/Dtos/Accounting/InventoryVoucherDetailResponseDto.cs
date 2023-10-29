using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class InventoryVoucherDetailResponseDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public int? DefaultPurchasePrice { get; set; }
        public string? BarCode { get; set; }
        public int? Tax { get; set; }
        public string? UnitName { get; set; }
        public int? Price { get; set; }
        public float? Quantity { get; set; }
        public int? DebitAccount { get; set; }
        public int? CreditAccount { get; set; }
        public int? PaymentDiscountAccount { get; set; }
        public int? TaxAccount { get; set; }
        public float? TotalMoneyBeforeTax { get; set; }
        public int? DebitAccountMoney { get; set; }
        public int? CreditAccountMoney { get; set; }
        public int? PaymentDiscountMoney { get; set; }
        public int? TaxMoney { get; set; }
        public int? TotalMoneyAfterTax { get; set; }
        public string? Note { get; set; }
    }
}
