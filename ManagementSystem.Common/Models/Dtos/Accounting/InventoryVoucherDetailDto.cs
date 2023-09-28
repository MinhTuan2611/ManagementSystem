using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class InventoryVoucherDetailDto
    {
        public int DocummentNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int TotalMoneyAfterTax { get; set; }
        public string Note { get; set; } = "";
    }
}
