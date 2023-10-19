using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftEndResponseDto
    {
        public int ShiftEndId { get; set; }
    }
}
