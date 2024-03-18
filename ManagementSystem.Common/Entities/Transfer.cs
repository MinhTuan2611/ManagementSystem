using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
public class Transfer : BaseEntity
{
        [Key]
        public int TransferId { get; set; }
        public string? UserCreating { get; set; }
        public int VoucherNumber { get; set; }
        public int BranchId { get; set; }
        public int SupplierId { get; set; }
        public int BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public DateTime ReceivingDay { get; set; }
        public DateTime ExportingDay { get; set; }
        public TransferStatus Status { get; set; } = TransferStatus.Created;
        public List<TransferItem> TransferItems { get; set; }
        public int StoreInId { get; set; }
        [ForeignKey("StoreInId")]
        public Storage StoreIn { get; set; }
        public int StoreOutId { get; set; }
        [ForeignKey("StoreOutId")]
        public Storage StoreOut { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
    }
}