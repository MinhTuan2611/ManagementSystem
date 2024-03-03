using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class DamagedGoodsStorageDto
    {
        public int? StorageId { get; set; }
        public string? StorageCode { get; set; }
        public string? StorageName { get; set; }
    }
}