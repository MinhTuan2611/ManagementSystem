﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class PaymentVoucherResponseDto
    {
        public int DocumentNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? ReceiverName { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public long? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public long? NTMoney { get; set; }
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
    }
}
