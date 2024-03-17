using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Products
{
    public class ProductReviewImportDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int DefaultPurchasePrice { get; set; }
        public int Price { get; set; }
        public string UnitName { get; set; }
        public int? UnitId { get; set; }

        public int? CategoryId { get; set; }

        public ImportProductStatus status { get; set; } = ImportProductStatus.Unchange;
    }
}
