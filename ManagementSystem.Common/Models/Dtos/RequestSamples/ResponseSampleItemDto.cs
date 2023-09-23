using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.RequestSamples
{
    public class ResponseSampleItemDto
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
    }
}
