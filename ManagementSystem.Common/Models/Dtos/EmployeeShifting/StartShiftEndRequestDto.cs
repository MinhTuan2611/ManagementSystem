namespace ManagementSystem.Common.Models.Dtos
{
    public class StartShiftEndRequestDto
    {
        public int? UserId { get; set; }
        public int BranchId { get; set; }
        public int ShiftId { get; set; }
    }
}
