using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class DebitVoucherResponseDto
    {
        public int DocumentNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? ReceiverName { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodCode { get; set; }
    }
}
