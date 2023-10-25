using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class DocumentGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int GroupId { get; set; }
        public int GroupName { get; set; }
    }
}
