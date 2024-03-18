using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class InvoiceModifyRequestDto
    {
        public string Ikey { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
        public string Buyer { get; set; }
        public string Email { get; set; }
        public string EmailCC { get; set; }
        public string CusAddress { get; set; }
        public string CusBankName { get; set; }
        public string CusBankNo { get; set; }
        public string CusPhone { get; set; }
        public string CusTaxCode { get; set; }
        public int Type { get; set; }
        public string PaymentMethod { get; set; }
        public string TaxAuthorityCode { get; set; }
        public string ArisingDate { get; set; }
        public string ExchangeRate { get; set; }
        public string CurrencyUnit { get; set; }
        public string Extra { get; set; }
        public List<ProductInvoiceDto> Products { get; set; }
        public double Total { get; set; }
        public float VATRate { get; set; }
        public float VATRateOther { get; set; }
        public double VATAmount { get; set; }
        public double Amount { get; set; }
        public double GrossValue { get; set; }
        public double GrossValue0 { get; set; }
        public double GrossValue5 { get; set; }
        public double GrossValue10 { get; set; }
        public double GrossValueNDeclared { get; set; }
        public double GrossValueContractor { get; set; }
        public double VatAmount0 { get; set; }
        public double VatAmount5 { get; set; }
        public double VatAmount10 { get; set; }
        public double VatAmountNDeclared { get; set; }
        public double VatAmountContractor { get; set; }
        public double Amount0 { get; set; }
        public double Amount5 { get; set; }
        public double Amount10 { get; set; }
        public double AmountNDeclared { get; set; }
        public double AmountOther { get; set; }
        public double GrossValue8 { get; set; }
        public double VatAmount8 { get; set; }
        public double Amount8 { get; set; }
        public string AmountInWords { get; set; }
    }
}
