using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class Request : BaseEntity
    {
        [Key]
        public int RequestId { get; set; }
        public int VoucherNumber { get; set; }
        public int BranchId { get; set; }
        public int StorageId { get; set; }
        public int SupplierId { get; set; }
        public int BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public DateTime ReceivingDay { get; set; }
        public int? TotalAmount { get; set; }
        public string? Signature { get; set; }
        public ReceiptStatus Status { get; set; } = ReceiptStatus.ChoDuyet;
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<RequestItem> RequestItemId { get; set; }
        public int UserId { get; set; }
        public string? Note { get; set; }
        public Branch Branch { get; set; }
        public Storage Storage { get; set; }
        public Supplier Supplier { get; set; }
    }
}