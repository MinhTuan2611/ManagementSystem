using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(128)]
        public string UserName { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }
        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
