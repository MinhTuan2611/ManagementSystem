using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class ProductUnitBranch : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ProductUnit")]
        public int ProductUnitId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public long Price { get; set; }

        public Branch? Branch { get; set; }
    }
}
