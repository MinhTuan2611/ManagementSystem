using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Accounting
{
    public class UpdateOtherAccountEntryDto
    {
        public int DocumentNumber { get; set; }
        public int? BrandId { get; set; }
        public int? CustomerId { get; set; }
        public int? Amount { get; set; }
        public string? Reason { get; set; }
        public string? PaymentDescription { get; set; }
        public int? UserId { get; set; }
        public int? AccountId { get; set; }
        public string? Note { get; set; }
    }
}
