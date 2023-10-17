using ManagementSystem.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class ShiftHandovers
    {
        [Key]
        public int HandoverId { get; set; }
        public int? StorageId { get; set; }
        public int? CashHandover { get; set; } = 0;
        public int? SenderUserId1 { get; set; }
        public int? SenderUserI2 { get; set; }
        public int? ReceiverUserId { get; set; }
        public int? TotalShiftMoney { get; set; }
        public int? CompanyMoneyTransferred { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        [ForeignKey("ShiftEndReport")]
        public int ShiftEndId { get; set; }
        public DateTime HandoverTime { get; set; } = DateTime.Now;

        public ShiftEndReport ShiftEndReport { get; set; }

    }
}
