using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class PaymentMethodDto
    {
        public int PaymentMethodId { get; set; }
        public string? PaymentMethodCode { get; set; }
        public string? PaymentMethodName { get; set; }
    }
}
