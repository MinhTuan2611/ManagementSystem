using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Accounting
{
    public class UpdateDebitVoucherRequestDto
    {
        public int DocumentNumber { get; set; }
        public int? UserId { get; set; }
        public string? ReceiverName { get; set; }
        public int? DebitAccount { get; set; }
        public int? CreditAccount { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public int ShiftId { get; set; }
        public string? PaymentMethodCode { get; set; }
    }
}
