using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.EmployeesApi.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
