using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class AnimalPartRefCode
    {
        [Key]
        public int AnimalPartId { get; set; }
        [Required]
        public string PartName { get; set; }
        [Required]
        [MaxLength(100)]
        public string RefCode { get; set; }
    }
}
