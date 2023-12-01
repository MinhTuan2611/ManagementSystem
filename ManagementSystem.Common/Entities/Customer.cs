using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        public int CustomerPoint { get; set; } = 0;

        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber  { get; set; }
    }
}
