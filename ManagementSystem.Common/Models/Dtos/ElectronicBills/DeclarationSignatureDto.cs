using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class DeclarationSignatureDto
    {
        public string OrganizationCA { get; set; }
        public string SerialCert { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int SigRegMethod { get; set; }
    }
}
