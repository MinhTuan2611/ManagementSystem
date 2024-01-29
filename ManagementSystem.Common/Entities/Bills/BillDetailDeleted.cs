using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class BillDetailDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; } = 0;
        public int UnitId { get; set; }
        public int DiscountAmount { get; set; } = 0;
        public int DiscountPercentage { get; set; } = 0;
        public bool DiscountByPercentage { get; set; } = false;
        public float Quantity { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public int? UserId { get; set; }
    }
}
