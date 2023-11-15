using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class OtherAccountEntryResponseDto
    {
        public int DocumentNumber { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? PayerName { get; set; }
        public int? Amount { get; set; }
        public string? Reason { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentDescription { get; set; }
        public int? AccountId { get; set; }
        public string? Note { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
    }
}
