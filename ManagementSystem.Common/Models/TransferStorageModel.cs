using ManagementSystem.Common.Entities;

namespace ManagementSystem.Common.Models
{
    public class TransferItemModel
    {
        public int TransferItemId { get; set; }
        public int ProductId { get; set; }
        public int TransferId { get; set; }
        public int Quantity { get; set; }
        public int ActualQuantity { get; set; }
        public int UnitId { get; set; }
        public string? Note { get; set; }
    }

    public class TransferModel
    {
        public int TransferId { get; set; }
        public string? UserCreating { get; set; }
        public int VoucherNumber { get; set; }
        public int BranchId { get; set; }
        public int? SupplierId { get; set; }
        public int BillNumber { get; set; }
        public string DeliverName { get; set; }
        public string DeliverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public DateTime? ReceivingDay { get; set; }
        public DateTime? ExportingDay { get; set; }
        public TransferStatus Status { get; set; } = TransferStatus.Created;
        public List<TransferItemModel>? TransferItems { get; set; }
        public int StoreInId { get; set; }
        public int StoreOutId { get; set; }
    }

    public class TransferApiModel<T>
    {
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public T? Item { get; set; }
    }

    public class TransferDTO : BaseEntity
    {
        public int TransferId { get; set; }
        public string UserCreating { get; set; }
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
        public string Status { get; set; }
        public List<TransferItem> TransferItems { get; set; }
        public int StoreInId { get; set; }
        public Storage StoreIn { get; set; }
        public int StoreOutId { get; set; }
        public Storage StoreOut { get; set; }
        public Branch Branch { get; set; }
        public Supplier Supplier { get; set; }
    }

    public class ItemDto {
        public int TransferItemId { get; set; }
        public int ProductId { get; set; }
        public int TransferStorageId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public string? Note { get; set; }
        public Product? Product { get; set; }
        public Unit? Unit { get; set; }
    }

    public class ResponseTransferDto
    {
        public List<TransferDTO> Data { get; set; }
        public int TotalRecord { get; set; }
    }

    public class StatusTransferModel
    {
        public int TransferId { get; set; }
        public TransferStatus TransferStatus { get; set; }
    }
}
