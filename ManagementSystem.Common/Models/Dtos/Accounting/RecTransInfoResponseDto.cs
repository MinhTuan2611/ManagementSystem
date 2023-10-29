using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models
{
    [Keyless]
    public class RecTransInfoResponseDto
    {
        public int? Id { get; set; }
        public string DocumentType { get; set; }
        public string ReasonGroup { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public string DebitAccountId { get; set; }
        public string CreditAccountId { get; set; }
        public string? ExpenseItem { get; set; }
        public ActiveStatus? Status { get; set; }
        public string? Note { get; set; }
    }
}
