using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class BillRefundRequestDto
    {
        public int? CustomerId { get; set; }
        public int UserId { get; set; } = 1;
        public int? BranchId { get; set; } = 1;
        public int? ShiftId { get; set; } = 1;
        public string? CustomerName { get; set; } = "Khach le";
        public int totalDeductibleAmount { get; set; } = 0;
        public string? PaymentMethodCode { get; set; } = "CASH";
        public List<ReturnedProductRequestDto>? ReturnedProduct { get; set; }
        public List<ExchangedProductRequestDto>? ExchangedProduct { get; set; }

    }
}
