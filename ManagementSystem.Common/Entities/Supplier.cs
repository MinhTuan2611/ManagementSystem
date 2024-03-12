using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Supplier: BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(100)]
        public string SupplierCode { get; set; }
        [MaxLength(128)]
        public string SupplierName { get; set; }
        [MaxLength(128)]
        public string DisplayName { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
        public string? Phone { get; set; }
        [MaxLength(128)]
        public string? PTTT { get; set; }
        [MaxLength(128)]
        public string? MSThue { get; set; }
        [MaxLength(500)]
        public string? DisplayAddress { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
