using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class PaymentVoucher
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? UserId { get; set; }
        [MaxLength(128)]
        public string? ReceiverName { get; set; }
        public int? BranchId { get; set; }
        [MaxLength(128)]
        public string? BranchCode { get; set; }
        [MaxLength(128)]
        public string? BranchName { get; set; }
        [MaxLength(128)]
        public string? DebitAccount { get; set; }
        [MaxLength(128)]
        public string? CreditAccount { get; set; }
        [MaxLength(500)]
        public string? Reason { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public long? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public long? NTMoney { get; set; }
        public int ShiftId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }

        public DocumentGroup DocumentGroup { get; set; }
    }
}
