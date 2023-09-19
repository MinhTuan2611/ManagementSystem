using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class RequestSampleItem : BaseEntity
    {
        public int UnitId { get; set; }
        public string ItemNote { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int RequestSampleId { get; set; }
        public virtual RequestSample requestSample { get; set; }
        public virtual Unit Unit { get; set; }

    }
}