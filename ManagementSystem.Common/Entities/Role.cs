using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
