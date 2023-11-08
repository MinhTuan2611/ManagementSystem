using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class InventoryAuditDetail
    {
        [ForeignKey("ShiftEndReport")]
        public int ShiftEndId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float ActualAmount { get; set; }
        public float SystemAmount { get; set; }

        public ShiftEndReport ShiftEndReport { get; set; }
    }
}
