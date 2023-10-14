using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class BillPaymentDetailResponseDto
    {
        public int? Id { get; set; }
        public string? PaymentMethodCode { get; set; }
        public string? PaymentMethodName { get; set; }
        public int? Amount { get; set; } = 0;
        public string? PaymentTransactionRef { get; set; }
    }
}
