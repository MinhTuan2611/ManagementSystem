using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? CreateBy { get; set; }
        public DateTime ModifyDate { get; set; } = DateTime.Now;
        public int? ModifyBy { get; set;}
    }
}
