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
        [MaxLength(30)]
        public string PaymentMethodCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string PaymentMethodName { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
