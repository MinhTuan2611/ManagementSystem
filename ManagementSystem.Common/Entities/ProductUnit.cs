using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class ProductUnit : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        [Required]
        public int UnitExchange { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; } = 0;
        [Required]
        public bool IsPrimary { get; set; }
        public string? Barcode { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public Product? Product { get; set; }
        public Unit? Unit { get; set; }
    }
}
