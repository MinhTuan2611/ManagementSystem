using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftHandoverResponseDto
    {
        public int? HandoverId { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? HandoverDate { get; set; }
        public int? TotalAmount { get; set; }
        public int? PreShiftAmount { get; set; }
        public int? CurShiftAmount { get; set; }
    }
}
