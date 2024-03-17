using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.ElectronicBills
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public int Method { get; set; }
        public DeclNormalInvDto DeclNormalInvDto { get; set; }
    }
}
