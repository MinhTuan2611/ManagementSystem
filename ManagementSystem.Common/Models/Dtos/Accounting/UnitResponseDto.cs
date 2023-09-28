using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Accounting
{
    [Keyless]
    public class UnitResponseDto
    {
        public string? UnitName { get; set; }
    }
}
