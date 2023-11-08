using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ProductAutoGenerationResponseDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductCode { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public float? TotalSystemAmount { get; set; } = 0;
    }
}
