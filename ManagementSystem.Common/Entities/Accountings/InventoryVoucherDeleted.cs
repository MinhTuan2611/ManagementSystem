using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class InventoryVoucherDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int? BillId { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? ShiftId { get; set; }
        public int? StorageId { get; set; }
        public string? PurchasingRepresentive { get; set; }
        public string? RepresentivePhone { get; set; }
        public string? ReasonFor { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string? Note { get; set; }
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }

        public int? GroupId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
