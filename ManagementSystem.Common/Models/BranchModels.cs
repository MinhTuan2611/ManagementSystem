using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class BranchInfo
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class BranchRequest
    {
        public int? UserId { get; set; }
        public int BranchId { get; set; }
    }

    public class UpdateBranchModel : BranchRequest
    {
        public BranchInfo Branch { get; set; }
    }

    
}
