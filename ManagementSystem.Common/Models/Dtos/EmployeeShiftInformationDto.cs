using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class EmployeeShiftInformationDto
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
