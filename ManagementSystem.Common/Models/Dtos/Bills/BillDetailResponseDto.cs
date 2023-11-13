using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class BillDetailResponseDto
    {
        public int? Id { get; set; }
        public int? DiscountAmount { get; set; }
        public Boolean? DiscountByPercentage { get; set; }
        public int? DiscountPercentage { get; set; }
        public float? Quantity { get; set; }
        public int? Amount { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public int? BillId { get; set; }
    }
}
