using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class BillSearchingResponseDto
    {
        public int BillId { get; set; }
        public int totalAmount { get; set; } = 0;
        public int totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
