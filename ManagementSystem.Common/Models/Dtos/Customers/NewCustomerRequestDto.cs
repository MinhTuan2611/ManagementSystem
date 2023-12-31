﻿using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Models
{
    public class NewCustomerRequestDto
    {
        public string CustomerCode { get; set; } = string.Empty;
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int CustomerPoint { get; set; } = 0;
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }

        [Phone]
        [MaxLength(15)]
        [RegularExpression(@"^[0-9]+$")]
        public string PhoneNumber { get; set; }
    }
}
