using ManagementSystem.Common.Entities.Bills;
using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Branch : BaseEntity
    {
        [Key]
        public int BranchId { get; set; }   
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? ManagerID { get; set; }
        public List<BranchVerification>? BranchVerifications { get; set; } = null;
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
