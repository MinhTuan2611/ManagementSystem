using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.ElectronicBills
{
    public class InvoiceRequestWithoutKeyDto
    {
        public string XmlData { get; set; }
        public string Pattern { get; set; }
    }
}
