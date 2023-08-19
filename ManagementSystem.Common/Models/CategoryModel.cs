namespace ManagementSystem.Common.Models
{
    public class CategoryInfo
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
