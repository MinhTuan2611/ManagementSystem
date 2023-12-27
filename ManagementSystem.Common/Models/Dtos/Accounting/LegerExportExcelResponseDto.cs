using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class LegerExportExcelResponseDto
    {
        public DateTime TransactionDate { get; set; }
        public string? DepositAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? DoccumentType { get; set; }
        public int? DoccumentNumber { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public long? Amount { get; set; }
        public string? ForReason { get; set; }

    }
}
