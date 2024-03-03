using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ProductUnitBranchResponseDto
    {
        public int? ProductUnitId { get; set; }
        public int? BranchId { get; set; }
        public long? Price { get; set; } = 0;
    }
}
