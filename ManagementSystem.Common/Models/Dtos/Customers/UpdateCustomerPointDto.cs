using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateCustomerPointDto
    {
        public int? CustomerId { get; set; }
        public int? Amount { get; set; }
        public int? UsedPoint { get; set; }
    }
}
