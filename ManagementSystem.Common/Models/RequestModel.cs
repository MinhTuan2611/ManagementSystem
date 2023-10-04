using ManagementSystem.Common.Entities;

namespace ManagementSystem.Common.Models
{
    public class RequestItemModel
    {
        public int RequestItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int UnitPrice { get; set; }
        public float Tax { get; set; } = 0;
        public decimal ProductAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public Product? Product { get; set; }
    }

    public class RequestModel
    {
        public int? RequestId { get; set; }
        public int VoucherNumber { get; set; }
        public int BranchId { get; set; }
        public int StorageId { get; set; }
        public int SupplierId { get; set; }
        public int BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string? DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public DateTime ReceivingDay { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<RequestItem> RequestItemId { get; set; }
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

    public class RequestApiModel<T>
    {
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public T? Item { get; set; }
    }



    //public class RequestedBranch
    //{
    //    public int BranchId { get; set; }
    //    public string? BranchName { get; set; }
    //    public string? BranchAddress { get; set; }
    //    public string? BranchContactName { get; set; }
    //    public string? BranchPhone { get; set; }
    //}

    //public class RequestedStorage
    //{
    //    public int StorageId { get; set; }
    //    public string? StorageName { get; set; }
    //    public string? StorageAddress { get; set; }
    //    public string? StoragePhone { get; set; }
    //}
}
