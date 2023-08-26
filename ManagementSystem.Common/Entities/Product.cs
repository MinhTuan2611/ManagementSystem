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
        public string? BarCode { get; set; }
        public string ProductName { get; set; }
        public string? Decription { get; set; }
        public int? CategoryId { get; set; }
        public ProductTypes ProductType { get; set; } = ProductTypes.Product;
        public int Price { get; set; }
        public int? Tax { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public int DefaultPurchasePrice { get; set; }
        public Category? Category { get; set; }
    }
}
