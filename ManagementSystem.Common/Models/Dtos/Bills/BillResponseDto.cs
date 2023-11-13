using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class BillResponseDto
    {
        public int? BillId { get; set; }
        public int? totalAmount { get; set; } = 0;
        public int? totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? TotalBillAmount { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int TotalProductDetail { get; set; }
        public List<BillDetailResponseDto> Details { get; set; }
        public List<BillPaymentDetailResponseDto> Payments { get; set; }
    }
}
