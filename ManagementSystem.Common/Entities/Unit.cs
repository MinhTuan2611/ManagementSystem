using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Unit : BaseEntity
    {
        [Key]
        public int UnitId { get; set; }
        [MaxLength(50)]
        public string UnitName { get; set; }
    }
}
