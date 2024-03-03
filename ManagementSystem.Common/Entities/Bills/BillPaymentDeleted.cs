using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class BillPaymentDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int BillId { get; set; } = 0;
        public int PaymentMethodId { get; set; }
        public int Amount { get; set; } = 0;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.UnPaid;
        public string? PaymentTransactionRef { get; set; }
        public int? UserId { get; set; }
    }
}
