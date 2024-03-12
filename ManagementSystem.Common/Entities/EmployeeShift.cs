using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class EmployeeShift
    {
        [Key]
        public int ShiftId { get; set; }
        [MaxLength(50)]
        public string ShiftName { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
    }
}
