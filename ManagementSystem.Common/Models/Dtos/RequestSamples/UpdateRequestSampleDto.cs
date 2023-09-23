using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateRequestSampleDto
    {
        [Required]
        public int RequestSampleId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public string RequestSampleName { get; set; }
        public int UserId { get; set; }
        public string RequestSampleNote { get; set; }
        public List<RequestSampleItemDto> RequestSampleItems { get; set; }
    }
}
