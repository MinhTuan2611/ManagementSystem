using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class UserBrandDto
    {
        public int? UserId { get; set; }
        public int? BrandId { get; set; }
    }
}
