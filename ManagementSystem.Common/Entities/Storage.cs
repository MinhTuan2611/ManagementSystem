using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Storage : BaseEntity
    {
        [Key]
        public int StorageId { get; set; }
        public string StorageCode { get; set; }
        public string StorageName { get; set; }
        public string? Address { get; set; }
        public string? Phone  { get; set; }
        public int? BranchId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public Branch? Branch { get; set; }
    }
}
