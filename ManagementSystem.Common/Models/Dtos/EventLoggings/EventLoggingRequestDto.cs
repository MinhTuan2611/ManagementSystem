using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class EventLoggingRequestDto
    {
        public int? UserId { get; set; }
        public string? MessageLogging { get; set; }
        public string? Source { get; set; }
    }
}
