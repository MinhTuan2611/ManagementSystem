using ManagementSystem.Common.Entities.Accountings;
using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class InventoryVoucher
    {

        [Key]
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? ShiftId { get; set; }
        public string? PurchasingRepresentive { get; set; }
        public string? RepresentivePhone { get; set; }
        public string? ReasonFor { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string? Note { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public List<InventoryVoucherDetail> Details { get; set; }
        public List<InventoryVoucherPaymentMethod> PaymentMethods { get; set; }
    }
}
