using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class CreditVoucher
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        //public string? ExtenalCustomer { get; set; }
        public string ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int? UserId { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
        public int? BillId { get; set; }

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }

        public DocumentGroup DocumentGroup { get; set; }

    }
}
