using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public  class ElectronicBill
    {
        [Key]
        public int Id { get; set; }
        public string? Result { get; set; }
        public int EBType { get; set; }
        public int? BillId { get; set; }
    }
}
