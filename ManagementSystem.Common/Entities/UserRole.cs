using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class UserRole : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User user { get; set; }
        public Role role { get; set; }
    }
}
