using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class PaymentMethodInformationDto
    {
        public string? TransactionDate { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public int? ShiftId { get; set; }
        public int? DocumentNumber { get; set; }
        public string? DebitAccount { get; set; }
        public string? CreditAccount { get; set; }
        public long? TotalMoneyVND { get; set; }
        public string? ReceiverName { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public string? CreatedUser { get; set; }
    }
}
