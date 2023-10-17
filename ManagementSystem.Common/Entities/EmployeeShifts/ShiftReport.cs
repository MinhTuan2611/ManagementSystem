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
        public int TotalShiftInMoney { get; set; } = 0;
        public int TotalRevenue { get; set; } = 0;
        public int TotalCashAmount { get; set; } = 0;
        public int TotalCardAmount { get; set; } = 0;
        public int TotalVoucherAmount { get; set; } = 0;
        public int TotalInternalConsumption { get; set; } = 0;
        public int TotalMOMOAmount { get; set; } = 0;
        public int TotalExpenses { get; set; } = 0;
        public int OtherExpense { get; set; } = 0;
        public int ActualMoneyForNextShift { get; set; } = 0;
        public int RemindMoneyForNextShift { get; set; } = 0;
        public int ExcessMoney { get; set; } = 0;
        public int LackOfMoney { get; set; } = 0;
        public DateTime ReportDate { get; set; } = DateTime.Now;

        public ShiftHandovers ShiftHandovers { get; set; }

    }
}
