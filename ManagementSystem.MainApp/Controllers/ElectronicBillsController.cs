using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.ElectronicBills;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicBillsController : ControllerBase
    {
        private ResponseDto _response;
        string path = "http://0317983888.softdreams.vn/";

        public ElectronicBillsController()
        {
            _response = new ResponseDto();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(BillInfo billInfo)
        {

            var model = await GenerateInvoiceInformation(billInfo);

            var xml = XMLCommonFunction.GenerateXml<InvoiceDto>(model, "Invoices", "Ivn");

            var request = new InvoiceRequestDto()
            {
                XmlData = xml,
                Pattern = MainConstants.ElectronicPartern
            };
            return Ok(billInfo);
        }

        #region Private handle methods
        private string GenerateToken(string httpMethod, string username, string password)
        {
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - epochStart;
            string timestamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();
            string nonce = Guid.NewGuid().ToString("N").ToLower();
            string signatureRawData = $"{httpMethod.ToUpper()}{timestamp}{nonce}";

            using (MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(signatureRawData));
                var signature = Convert.ToBase64String(hash);
                return $"{signature}:{nonce}:{timestamp}:{username}:{password}";
            }
        }

        private async Task<IEnumerable<InvoiceDto>> GenerateInvoiceInformation(BillInfo billInfo)
        {
            var invoices = new List<InvoiceDto>();

            var customer = new CustomerResponseDto();
            var invoice = new InvoiceDto();

            if (billInfo.CustomerId != null || billInfo.CustomerId.Value > 0)
            {
                customer = await GetCustomerInformation(billInfo.CustomerId.Value);
            }

            if (customer != null)
            {
                invoice.Ikey = billInfo.BillId.ToString();
                invoice.Buyer = customer.CustomerName;
                invoice.CusCode = customer.CustomerCode;
                invoice.CusName = customer.CustomerName;
                invoice.CusAddress = customer.Address;
                invoice.CusPhone = customer.PhoneNumber;
            }
            invoice.TaxAuthorityCode = MainConstants.TaxAuthorityCode;
            
            var products = new List<ProductInvoiceDto>();

            foreach (var item in billInfo.Details)
            {
                var product = await GetProductDetail(item.ProductId, item.UnitId);
                ProductInvoiceDto detail = new ProductInvoiceDto();

                detail.Code = product.ProductCode;
                detail.No = product.ProductId;
                detail.ProdName = product.ProductName;
                detail.ProdUnit = product.UnitName;
                detail.ProdQuantity = item.Quantity;
                detail.Discount = item.DiscountPercentage;
                detail.DiscountAmount = item.DiscountAmount;
                detail.Total = item.Amount;
                detail.VATRate = product.Tax;

                products.Add(detail);
            }

            invoices.Add(invoice);

            return invoices;
        }

        private async Task<CustomerResponseDto> GetCustomerInformation(int customerId) {
            var result = await HttpRequestsHelper.Get<CustomerResponseDto>(SD.StorageApiUrl + "customers/get-detail?id=" + customerId);

           return result;
        }

        private async Task<ProductDetailResponseDto> GetProductDetail(int productId, int unitId)
        {
            var result = await HttpRequestsHelper.Get<ProductDetailResponseDto>(SD.StorageApiUrl + "products/get-detail-by-id-unitid?productId=" + productId + "&unitId=" + unitId);

            return result;
        }
        #endregion
    }
}
