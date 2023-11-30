using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Accounting
{
    public class NewDebitVoucherRequestDto
    {
        public int? UserId { get; set; }
        public string? ReceiverName { get; set; }
        public string? Reason { get; set; }
        public string? Description { get; set; }
        public int? TotalMoneyVND { get; set; }
        public int? ExchangeRate { get; set; }
        public int? NTMoney { get; set; }
        public int ShiftId { get; set; }
        public string? PaymentMethodCode { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? BillId { get; set; }
        public int? StorageId { get; set; }
        public int? GroupId { get; set; }
    }
}
