using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class ShiftReport
    {
        [Key]
        public int ReportId { get; set; }
        public int? ShiftId { get; set; }
        public int? UserCreatedId { get; set; }

        [ForeignKey("ShiftHandovers")]
        public int? HandoverId { get; set; }
        public int TotalBill { get; set; } = 0;
        public long TotalShiftInMoney { get; set; } = 0;
        public long TotalRevenue { get; set; } = 0;
        public long TotalCashAmount { get; set; } = 0;
        public long TotalCardAmount { get; set; } = 0;
        public long TotalVoucherAmount { get; set; } = 0;
        public long TotalInternalConsumption { get; set; } = 0;
        public long TotalMOMOAmount { get; set; } = 0;
        public long TotalExpenses { get; set; } = 0;
        public long OtherExpense { get; set; } = 0;
        public long ActualMoneyForNextShift { get; set; } = 0;
        public long RemindMoneyForNextShift { get; set; } = 0;
        public long ExcessMoney { get; set; } = 0;
        public long LackOfMoney { get; set; } = 0;
        public DateTime ReportDate { get; set; } = DateTime.Now;

        public ShiftHandovers ShiftHandovers { get; set; }

    }
}