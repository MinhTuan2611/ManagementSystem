using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class NewPaymentVoucherDto
    {
        public int? UserId { get; set; }
        public string? ReceiverName { get; set; }
        public int? BranchId { get; set; }
        public string? DebitAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public int ShiftId { get; set; }
    }
}
