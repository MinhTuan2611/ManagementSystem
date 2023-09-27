using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class NewReceiptRequestDto
    {
        public int? CustomerId { get; set; }
        public string ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int UserId { get; set; }
    }
}
