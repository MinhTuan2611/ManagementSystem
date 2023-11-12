using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ProductDetailResponseDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal DefaultPurchasePrice { get; set; }
        public string BarCode { get; set; }
        public int Tax { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
    }
}
