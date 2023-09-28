using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ProductResponseDto
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int PriceBeforeTax { get; set; }
        public int CreditAccountId { get; set; }
        public int DebitAccountId { get; set; }
    }
}
