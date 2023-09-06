using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class PaymentMethod : BaseEntity
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Required]
        public string PaymentMethodCode { get; set; }

        [Required]
        public string PaymentMethodName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
