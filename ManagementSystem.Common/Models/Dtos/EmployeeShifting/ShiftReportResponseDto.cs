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
        public long TotalShiftInMoney { get; set; } = 0;
        public long TotalRevenue { get; set; } = 0;
        public long TotalCashAmount { get; set; } = 0;
        public long TotalCardAmount { get; set; } = 0;
        public long TotalVoucherAmount { get; set; } = 0;
        public long TotalInternalConsumption { get; set; } = 0;
        public long TotalMOMOAmount { get; set; } = 0;
        public long TotalPointAmount { get; set; } = 0;
        public long TotalExpenses { get; set; } = 0;
        public long OtherExpense { get; set; } = 0;
        public long ActualMoneyForNextShift { get; set; } = 0;
        public long RemindMoneyForNextShift { get; set; } = 0;
        public long ExcessMoney { get; set; } = 0;
        public long LackOfMoney { get; set; } = 0;
        public DateTime ShiftEndDate { get; set; }
    }
}
