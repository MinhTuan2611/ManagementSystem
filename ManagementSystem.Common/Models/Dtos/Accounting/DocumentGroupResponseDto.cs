using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class DocumentGroupResponseDto
    {
        public DateTime TransactionDate { get; set; }
        public string? DepositAccount { get; set; }
        public string? CreditAccount { get; set; }
        public int? DoccumentNumber { get; set; }
        public string? DoccumentType { get; set; }
        public int? BillId { get; set; }
        public int? Amount { get; set; }
        public string LegerDescription { get; set; }
    }
}
