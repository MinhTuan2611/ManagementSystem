using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class ShiftHandoverCashDetail
    {
        [ForeignKey("ShiftEndReport")]
        public int ShiftEndId { get; set; }
        public int Denomination { get; set; }
        public int Amount { get; set; }
        public int? AmountReceive { get; set; }

        public ShiftEndReport ShiftEndReport { get; set; }

    }
}