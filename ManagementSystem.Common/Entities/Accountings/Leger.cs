using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Leger
    {
        [Key]
        public int LegerId { get; set; }
        public DateTime TransactionDate { get; set; }
        [MaxLength(128)]
        public string? CreditAccount { get; set; }
        [MaxLength(128)]
        public string? DepositAccount { get; set; }
        [MaxLength(50)]
        public string DoccumentType { get; set; }

        public int DoccumentNumber { get; set; }
        public int? BillId { get; set; }
        public int? CustomerId { get; set; }
        [MaxLength(128)]
        public string? CustomerName { get; set; }
        public float Amount { get; set; }
        public int? UserId { get; set; }
        public int? StorageId { get; set; }
    }
}
