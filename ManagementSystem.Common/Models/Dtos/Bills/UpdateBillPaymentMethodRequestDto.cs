using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateBillPaymentMethodRequestDto
    {
        public int? Id { get; set; }
        public string PaymentMethodCode { get; set; }
        public float Amount { get; set; } = 0;
        public string? PaymentTransactionRef { get; set; }
    }
}
