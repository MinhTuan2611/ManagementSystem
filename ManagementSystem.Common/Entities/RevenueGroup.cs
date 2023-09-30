using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class RevenueGroup
    {
        [Key]
        public int RevenueGroupId { get; set; }
        public string RevenueGroupName { get; set; }
    }
}
