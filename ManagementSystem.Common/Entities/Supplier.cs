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
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
