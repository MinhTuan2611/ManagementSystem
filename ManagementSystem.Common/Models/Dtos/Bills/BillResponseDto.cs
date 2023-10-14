using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class BillResponseDto
    {
        public int? BillId { get; set; }
        public List<BillDetailResponseDto> BillDetails { get; set; }
        public List<BillPaymentDetailResponseDto> BillPaymentMethods { get; set; }
    }
}
