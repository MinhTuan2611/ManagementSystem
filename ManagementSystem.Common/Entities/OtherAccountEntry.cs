using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class OtherAccountEntry
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? BrandId { get; set; }
        public int? CustomerId { get; set; }
        public int? Amount { get; set; }
        public string? Reason { get; set; }
        public string? PaymentDescription { get; set; }
        public int? UserId { get; set; }
        public int? AccountId { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
