using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class ProductStorageInformationDto
    {
        public int? StorageId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
