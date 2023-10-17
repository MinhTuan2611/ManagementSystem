using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class NewEmployeeShiftEndRequestDto
    {
        public int? ShiftId { get; set; }
        public int? UserId { get; set; }
        public DateTime ShiftEndDate { get; set; }
        public int? CompanyMoneyTransferred { get; set; }

        public List<NewInventoryAuditDetailDto> AuditDetails { get; set; }
        public List<NewShiftHandoverCashDetailDto> ShiftHandoverCashDetails { get; set; }
    }
}
