using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class BranchRequest
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class UpdateBranchModel
    {
        public int BranchId { get; set; }
        public BranchRequest Branch { get; set; }
    }
}
