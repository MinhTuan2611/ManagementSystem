using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class DiscountInformationDto
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public int BillId { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public int TotalAmountBeforeDiscount { get; set; } = 0;
        public int TotalDiscountAmount { get; set; } = 0;
        public int TotalAmount { get; set; } = 0;
    }
}
