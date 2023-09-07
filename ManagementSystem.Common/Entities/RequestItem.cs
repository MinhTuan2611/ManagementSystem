using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class RequestItem : BaseEntity
    {
        [Key]
        public int RequestItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int UnitPrice { get; set; }
        public float Tax { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public Product? Product { get; set; }
    }
}