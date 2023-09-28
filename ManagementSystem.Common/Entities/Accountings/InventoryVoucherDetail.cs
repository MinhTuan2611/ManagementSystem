using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class InventoryVoucherDetail
    {
        [ForeignKey("InventoryVoucher")]
        public int DocummentNumber { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? DebitAccount { get; set; }
        public int? CreditAccount { get; set; }
        public int? TotalMoneyBeforeTax { get; set; }
        public int? DebitAccountMoney { get; set; }
        public int? CreditAccountMoney { get; set; }
        public int? PaymentDiscountAccount { get; set; }
        public int? PaymentDiscountMoney { get; set; }
        public int? TaxAccount { get; set; }
        public int? TaxMoney { get; set; }
        public int? TotalMoneyAfterTax { get; set; }
        public string? Note { get; set; }
        public int? StorageId { get; set; }
        public InventoryVoucher InventoryVoucher { get; set; }

    }

}
