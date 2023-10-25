using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class PaymentVoucher
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? UserId { get; set; }
        public string? ReceiverName { get; set; }
        public int? BranchId { get; set; }
        public int? DebitAccount { get; set; }
        public int? CreditAccount { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public int ShiftId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }

        public DocumentGroup DocumentGroup { get; set; }
    }
}
