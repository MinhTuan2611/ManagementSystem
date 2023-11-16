using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftEndReportView
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

        public int? Denomination { get; set; }
        public int? Amount { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public float? ActualAmount { get; set; }
        public float? SystemAmount { get; set; }
    }
}
