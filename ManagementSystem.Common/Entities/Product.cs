using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int DefaultSalePrice { get; set; }
        public int DefaultPurchasePrice { get; set; }
        public int UnitId { get; set; }
        public Category? Category { get; set; }
        public Unit Unit { get; set; }
    }
}
