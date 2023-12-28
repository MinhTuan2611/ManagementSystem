using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class ExchangedProductRequestDto
    {
        public int? DocummentNumber { get; set; } = 1;
        public int ProductId { get; set; }
        public int Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int? Amount { get; set; } = 0;
        public int UnitId { get; set; }
        public int? TotalMoneyAfterTax { get; set; } = 0;
        public string? Note { get; set; } = "";
        public int? PaymentDiscountMoney { get; set; } = 0;
    }
}