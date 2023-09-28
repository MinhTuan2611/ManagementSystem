using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class PaymentVoucher
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int BranchId { get; set; }
        public int DebitAccount { get; set; }
        public int CreditAccount { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
