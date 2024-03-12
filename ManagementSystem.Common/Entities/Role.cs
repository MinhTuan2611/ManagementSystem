using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string RoleCode { get; set; }
        [MaxLength(128)]
        public string RoleName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
