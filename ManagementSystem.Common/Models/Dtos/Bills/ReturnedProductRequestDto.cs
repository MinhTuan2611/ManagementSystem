using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class ReturnedProductRequestDto
    {
        public int ProductId { get; set; }
        public int? Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int? Amount { get; set; } = 0;
        public string? Reason { get; set; } = "HU";
        public string? Action { get; set; } = "HOANTIEN";
        }
}