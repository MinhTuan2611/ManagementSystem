using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class BillPayment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int BillId { get; set; } = 0;
        public int PaymentMethodId { get; set; }
        public float Amount { get; set; } = 0;
        public Bill Bill { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.UnPaid;
        public string? PaymentTransactionRef { get; set; }
    }
}
