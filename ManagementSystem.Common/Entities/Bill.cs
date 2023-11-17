using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Bill : BaseEntity
    {
        [Key]
        public int BillId { get; set; }
        public int totalAmount { get; set; } = 0;
        public int totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public int? ShiftId { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public Customer? Customer { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.UnPaid;
        public bool IsAutoComplete { get; set; }= false;
    }
}
