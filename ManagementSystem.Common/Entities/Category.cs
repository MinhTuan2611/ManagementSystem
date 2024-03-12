using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(128)]
        public string CategoryName { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int CategoryRefCode { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
