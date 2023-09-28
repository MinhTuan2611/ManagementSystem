using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ReceiptResponseDto
    {
        public int DocumentNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Payer { get; set; }
        public string? ForReason { get; set; }
        public int? TotalMoney { get; set; }
        public int UserId { get; set; }
        public string Cashier { get; set; }
    }
}
