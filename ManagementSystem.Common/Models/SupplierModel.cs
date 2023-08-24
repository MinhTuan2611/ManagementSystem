using ManagementSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class SupplierInfo
    {
        public int? SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
    public class SupplierRequest
    {
        public int? UserId { get; set; }
        public int SupplierId { get; set; } = 0;
    }

    public class UpdateSupplierModel : SupplierRequest
    {
        public SupplierInfo Supplier { get; set; }
    }
}
