using ManagementSystem.Common.Entities;

namespace ManagementSystem.Common.Models
{
    public class CategoryInfo
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
    public class CategoryUpdateRequest
    {
        public Category category { get; set; }
        public int userId { get; set; }
    }
}
