using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class TransferItem : BaseEntity
    {
        [Key]
        public int TransferItemId { get; set; }
        public int ProductId { get; set; }
        public int TransferId { get; set; }
        public int Quantity { get; set; }
        public int ActualQuantity { get; set; } = 0;
        public int UnitId { get; set; }
        public string? Note { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }
    }
}