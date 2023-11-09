using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class ProductInvoiceDto
    {
        public string Code { get; set; }
        public int No { get; set; }
        public string Feature { get; set; }
        public string ProdName { get; set; }
        public string ProdUnit { get; set; }
        public float ProdQuantity { get; set; }
        public float Discount { get; set; }
        public float DiscountAmount { get; set; }
        public double Total { get; set; }
        public float VATRate { get; set; }
        public float VATRateOther { get; set; }
        public double VATAmount { get; set; }
        public double Amount { get; set; }
        public string Extra { get; set; }
    }
}
