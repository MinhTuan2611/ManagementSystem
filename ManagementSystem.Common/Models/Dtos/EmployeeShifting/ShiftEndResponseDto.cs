using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftEndResponseDto
    {
        public int ShiftEndId { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? ShiftEndDate { get; set; } = DateTime.Now;
        public int? CompanyMoneyTransferred { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public List<CashDetailDto> CashDetails { get; set; }
        public List<InventoryAuditDetailDto> InventoryAuditDetails { get; set; }
    }
}
