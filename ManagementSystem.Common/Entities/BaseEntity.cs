using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    internal class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User? CreateBy { get; set; }
        public DateTime ModifyDate { get; set; } = DateTime.Now;
        public User? ModifyBy { get; set;}
    }
}
