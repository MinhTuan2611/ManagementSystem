using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class LegerResponseDto
    {
        public DateTime TransactionDate { get; set; }
        public int? DepositAccount { get; set; }
        public int? CreditAccount { get; set; }
        public int? DoccumentNumber { get; set; }
        public string? DoccumentType { get; set; }
        public int? BillId { get; set; }
        public int? Amount { get; set; }
    }
}
