using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class ReceiptVoucherDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocumentNumber { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        //public string? ExtenalCustomer { get; set; }
        public string ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int UserId { get; set; }
        public int? BillId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;

        public int? GroupId { get; set; }

    }
}
