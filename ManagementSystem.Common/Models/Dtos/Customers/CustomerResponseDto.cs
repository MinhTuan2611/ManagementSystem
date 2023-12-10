using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Models
{
    [Keyless]
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public int? CustomerPoint { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
