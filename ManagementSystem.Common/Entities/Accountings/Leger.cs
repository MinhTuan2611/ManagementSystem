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
        public int? CreditAccount { get; set; }
        public int? DepositAccount { get; set; }
        public string DoccumentType { get; set; }
        public int DoccumentNumber { get; set; }
        public int? BillId { get; set; }
        public int? CustomerId { get; set; }
        public int Amount { get; set; }
        public int? UserId { get; set; }
        public int? StorageId { get; set; }
    }
}
