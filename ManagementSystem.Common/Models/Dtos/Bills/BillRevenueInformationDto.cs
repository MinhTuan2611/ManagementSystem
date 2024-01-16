using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class BillRevenueInformationDto
    {
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? TransactionDate { get; set; }
        public string? DepositAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? DoccumentType { get; set; }
        public int? DoccumentNumber { get; set; }
        public int? BillId { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public long? Amount { get; set; }
        public string? ForReason { get; set; }
    }
}
