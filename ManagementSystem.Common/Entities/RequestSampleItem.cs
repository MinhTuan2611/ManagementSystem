using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class RequestSampleItem : BaseEntity
    {
        [Key]
        public int RequestSampleItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public string? Note { get; set; }
        public Product? Product { get; set; }
        public RequestSample? requestSample { get; set; }
    }
}