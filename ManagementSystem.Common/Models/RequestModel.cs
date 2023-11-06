using ManagementSystem.Common.Entities;

namespace ManagementSystem.Common.Models
{
    public class ReceiptDetailModel
    {
        public int? RequestItemId { get; set; }
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public string? Unit { get; set; }
        public int UnitPrice { get; set; }
        public float Tax { get; set; } = 0;
        public decimal ProductAmount { get; set; }
        public decimal TaxAmount { get; set; } = 0;
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public Product? Product { get; set; }
    }

    public class RequestModel
    {
        public int? RequestId { get; set; }
        public int? VoucherNumber { get; set; }
        public int BranchId { get; set; }
        public int StorageId { get; set; }
        public int SupplierId { get; set; }
        public string BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string? DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public int? TotalAmount { get; set; }
        public string? Signature { get; set; }
        public string? Status { get; set; }
        public ReceiptStatus? StatusCode { get; set; }
        public int? UpdateType { get; set; }
        public DateTime ReceivingDay { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<ReceiptDetailModel> ReceiptDetails { get; set; }
        public int? UserId { get; set; }
        public string? Note { get; set; }
        public int? CreditAccount { get; set; }
        public int? CreditAmount { get; set; }
        public int? DebitAccount { get; set; }
        public int? DebitAmount { get; set; }
        public Branch? Branch { get; set; }
        public Storage? Storage { get; set; }
        public Supplier? Supplier { get; set; }
    }

    public class RequestInfo
    {
        public int RequestId { get; set; }
        public int VoucherNumber { get; set; }
        public string BranchName { get; set; }
        public string StorageName { get; set; }
        public string SupplierName { get; set; }
        public string BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string? DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public DateTime ReceivingDay { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public int? TotalAmount { get; set; }
        public string? Signature { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public string? Note { get; set; }
    }

    public class RequestApiModel<T>
    {
        public int UserId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public T? Item { get; set; }
    }
}
