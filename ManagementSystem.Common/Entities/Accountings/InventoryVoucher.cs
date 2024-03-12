using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class InventoryVoucher
    {

        [Key]
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int? BillId { get; set; }
        public int? CustomerId { get; set; }
        [MaxLength(128)]
        public string? CustomerName { get; set; }
        public int? ShiftId { get; set; }
        public int? StorageId { get; set; }
        [MaxLength(128)]
        public string? PurchasingRepresentive { get; set; }
        [MaxLength(15)]
        public string? RepresentivePhone { get; set; }
        [MaxLength(500)]
        public string? ReasonFor { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [MaxLength(500)]
        public string? Note { get; set; }
        [MaxLength(128)]
        public string? CreditAccount { get; set; }
        [MaxLength(128)]
        public string? DebitAccount { get; set; }

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;

        public DocumentGroup DocumentGroup { get; set; }
        public List<InventoryVoucherDetail> Details { get; set; }
    }
}
