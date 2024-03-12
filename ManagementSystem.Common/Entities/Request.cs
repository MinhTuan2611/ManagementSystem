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
        [MaxLength(128)]
        public string DeliverName { get; set; }
        [MaxLength(15)]
        public string DeliverPhone { get; set; }
        [MaxLength(128)]
        public string ReceiverName { get; set; }
        [MaxLength(15)]
        public string ReceiverPhone { get; set; }
        public DateTime ReceivingDay { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<RequestItem> RequestItemId { get; set; }
        public int UserId { get; set; }
        public string? Note { get; set; }
        public int? CreditAccount { get; set; }
        public int? CreditAmount { get; set; }
        public int? DebitAccount { get; set; }
        public int? DebitAmount { get; set; }
        public Branch Branch { get; set; }
        public Storage Storage { get; set; }
        public Supplier Supplier { get; set; }
    }
}