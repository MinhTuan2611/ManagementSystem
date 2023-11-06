using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class BillDetail : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; } = 0;
        public int UnitId { get; set; }
        public int DiscountAmount { get; set; } = 0;
        public int DiscountPercentage { get; set; } = 0;
        public bool DiscountByPercentage { get; set; } = false;
        public float Quantity { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public Bill Bill { get; set; }
    }
}
