using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class LegerExcelView
    {
        public DateTime TransactionDate { get; set; }
        public string? DepositAccount { get; set; }
        public string? CreditAccount { get; set; }
        public int? DoccumentNumber { get; set; }
        public string? DoccumentType { get; set; }
        public int? Amount { get; set; }
        public string LegerDescription { get; set; }
    }
}
