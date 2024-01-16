using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class PaymentMenthodReasonRef
    {
        [MaxLength(50)]
        public string MethodCode { get; set; }
        [MaxLength(50)]
        public string ReasonCode { get; set; }
    }
}
