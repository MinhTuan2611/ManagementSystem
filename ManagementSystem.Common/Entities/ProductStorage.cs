using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class ProductStorage : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public float Quantity { get; set; } = 0;
        public Product Product { get; set; }
        public Storage Storage { get; set; }
    }
}
