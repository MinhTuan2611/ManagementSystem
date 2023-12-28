using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class ProductStorageDto
    {
        public int ProductId { get; set; }
        public int? StorageId { get; set; }
        public int? Quantity { get; set; }
    }
}