using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public  class ElectronicBill
    {
        [Key]
        public string EKey { get; set; }
        public string? Result { get; set; }
        public int EBType { get; set; }
        public int? BillId { get; set; }
    }
}
