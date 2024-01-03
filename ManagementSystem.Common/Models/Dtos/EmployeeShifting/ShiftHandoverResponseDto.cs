using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ShiftHandoverResponseDto
    {
        public int? HandoverId { get; set; }
        public int? ShiftId { get; set; }
        public int? ShiftEndId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? HandoverDate { get; set; }
        public int? TotalAmount { get; set; }
        public long? PreShiftAmount { get; set; }
        public long? CurShiftAmount { get; set; }
        public int? SenderId1 { get; set; }
        public string? SenderName1 { get; set; }
        public int? SenderId2 { get; set; }
        public string? SenderUser2 { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public int? StorageId { get; set; }
        public string? StorageName { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public int? BranchId { get; set;}
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
    }
}
