using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class InventoryVoucherResponseDto
    {
        public int DocummentNumber { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? PurchasingRepresentive { get; set; }
        public string? RepresentivePhone { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string ReasonFor { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? StorageName { get; set; }
        public int? InventoryCreditAccout { get; set; }
        public int? InventoryDebitAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
        public int? BillId { get; set; }

        public List<BillPaymentDetailResponseDto> PaymentMethods { get; set; }
    }
}