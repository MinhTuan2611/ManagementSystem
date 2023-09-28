using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Receipt
    {
        [Key]
        public int DocumentNumber { get; set; }
        public int? CustomerId { get; set; }
        public string ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;

    }
}
