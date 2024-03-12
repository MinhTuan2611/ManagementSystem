using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(128)]
        public string? CustomerName { get; set; }
        public int? Amount { get; set; }
        [MaxLength(500)]
        public string? Reason { get; set; }
        [MaxLength(500)]
        public string? PaymentDescription { get; set; }
        public int? UserId { get; set; }
        public int? AccountId { get; set; }
        public string? Note { get; set; }
        [MaxLength(128)]
        public string? CreditAccount { get; set; }
        [MaxLength(128)]
        public string? DebitAccount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [ForeignKey("DocumentGroup")]
        public int? GroupId { get; set; }

        public DocumentGroup DocumentGroup { get; set; }
    }
}
