﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class DebitVoucher
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? UserId { get; set; }
        public string? ReceiverName { get; set; }
        public string? DebitAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public int ShiftId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int PaymentMethodId { get; set; }

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }
        public DocumentGroup DocumentGroup { get; set; }
    }
}
