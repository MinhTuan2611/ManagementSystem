using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftReportResponseDto
    {
        public int? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? TotalBill { get; set; }
        public int? TotalShiftInMoney { get; set; } = 0;
        public int? TotalRevenue { get; set; } = 0;
        public int? TotalCashAmount { get; set; } = 0;
        public int? TotalCardAmount { get; set; } = 0;
        public int? TotalVoucherAmount { get; set; } = 0;
        public int? TotalInternalConsumption { get; set; } = 0;
        public int? TotalMOMOAmount { get; set; } = 0;
        public int? TotalExpenses { get; set; } = 0;
        public int? OtherExpense { get; set; } = 0;
        public int? ActualMoneyForNextShift { get; set; } = 0;
        public int? RemindMoneyForNextShift { get; set; } = 0;
        public int? ExcessMoney { get; set; } = 0;
        public int? LackOfMoney { get; set; } = 0;
        public DateTime ShiftEndDate { get; set; }
    }
}
