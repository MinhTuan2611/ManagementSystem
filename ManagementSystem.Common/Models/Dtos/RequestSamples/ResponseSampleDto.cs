using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.RequestSamples
{
    public class ResponseSampleDto
    {
        public int RequestSampleId { get; set; }
        public string RequestSampleName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set;}
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<ResponseSampleItemDto> ResponseSampleItemDto { get; set; }
    }
}
