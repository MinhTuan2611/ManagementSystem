using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Models
{
    public class NewRequestSampleDto
    {
        [Required]
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string RequestSampleName { get; set; }
        public string RequestSampleNote { get; set; }
        public List<RequestSampleItemDto> RequestSampleItems { get; set; }
    }
}
