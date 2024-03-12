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
        [MaxLength(100)]
        public string StorageCode { get; set; }
        [MaxLength(128)]
        public string StorageName { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
        [MaxLength(15)]
        public string? Phone  { get; set; }
        public int? BranchId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public Branch? Branch { get; set; }
    }
}
