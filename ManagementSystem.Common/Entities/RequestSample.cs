using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class RequestSample : BaseEntity
    {
        [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestSampleId { get; set; }
        public string RequestSampleName { get; set; }
        public int UserId { get; set; }
        public string? RequestSampleNote { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public virtual ICollection<RequestSampleItem> RequestSampleItems { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}