using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class ShiftEndReport
    {
        [Key]
        public int ShiftEndId { get; set; }
        public int? UserId { get; set; }
        public int? ShiftId { get; set; }
        public DateTime ShiftEndDate { get; set; } = DateTime.Now;
        public int? CompanyMoneyTransferred { get; set; }
        public int? BranchId { get; set; }
        public List<ShiftHandoverCashDetail> ShiftHandoverCashDetails { get; set; }
        public List<InventoryAuditDetail> InventoryAuditDetails { get; set; }
    }
}
        