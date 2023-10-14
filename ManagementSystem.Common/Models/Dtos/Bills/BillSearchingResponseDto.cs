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
    }
}
