﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class CreditVoucherResponseDto
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
        public string PaymentMethodName { get; set; }
        public string PaymentMethodCode { get; set; }
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
        public int? BranchId { get; set; }
    }
}
