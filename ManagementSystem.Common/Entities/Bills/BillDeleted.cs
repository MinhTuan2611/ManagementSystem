using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class BillDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillId { get; set; }
        public int totalAmount { get; set; } = 0;
        public int totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public int? ShiftId { get; set; }
        public int? BranchId { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.UnPaid;
        public bool IsAutoComplete { get; set; }= false;
        public int? UserId { get; set; }
    }
}
