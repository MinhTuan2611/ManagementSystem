using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class NewInventoryAuditDetailDto
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public int ActualAmount { get; set; }
    }
}
