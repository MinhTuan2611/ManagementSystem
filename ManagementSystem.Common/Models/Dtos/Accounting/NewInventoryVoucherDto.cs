using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class NewInventoryVoucherDto
    {
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeShiftId { get; set; }
        public int? BrandId { get; set; }
        public int? BillId { get; set; }
        public string PurchasingRepresentive { get; set; }
        public string Note { get; set; } = "";
        public List<string> PaymentMethodCodes { get; set; }

        public List<InventoryVoucherDetailDto> Details { get; set; }
    }
}
