using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class InventoryVoucherDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InventoryVoucher")]
        public int DocummentNumber { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
        public float? Quantity { get; set; }
        public int? Price { get; set; }
        public int? DebitAccount { get; set; }
        public int? CreditAccount { get; set; }
        public float? TotalMoneyBeforeTax { get; set; }
        public int? DebitAccountMoney { get; set; }
        public int? CreditAccountMoney { get; set; }
        public int? PaymentDiscountAccount { get; set; }
        public int? PaymentDiscountMoney { get; set; }
        public int? TaxAccount { get; set; }
        public int? TaxMoney { get; set; }
        public int? TotalMoneyAfterTax { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
        public InventoryVoucher InventoryVoucher { get; set; }

    }

}
