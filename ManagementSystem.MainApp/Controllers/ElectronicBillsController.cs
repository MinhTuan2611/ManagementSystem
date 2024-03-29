﻿using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Functions;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.ElectronicBills;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicBillsController : ControllerBase
    {
        private ResponseDto _response;

        public ElectronicBillsController()
        {
            _response = new ResponseDto();
        }


        [HttpPost("publish/importAndPublishInvoice")]
        public async Task<IActionResult> Create(BillInfo billInfo)
        {

            var model = await GenerateInvoiceInformation(billInfo);

            string invoicesXml = XMLCommonFunction.GenerateXml(model.ToList());

            ElectronicPattern pattern = await HttpRequestsHelper.Get<ElectronicPattern>(SD.StorageApiUrl + "ElectronicBill/get_lastest_electronic_pattern");
            var request = new InvoiceRequestWithoutKeyDto()
            {
                XmlData = invoicesXml,
                Pattern = pattern.PatternCode
            };

            string authen = GenerateToken("POST");

            var result = await HttpRequestsHelper.PostAuthorize<object>(SD.EUrl + "api/publish/importInvoice", request, authen);

            var electronicModel = new ElectronicBill
            {
                EKey = model.ToList().FirstOrDefault().Ikey,
                Result = result.ToString(),
                EBType = StorageContant.CreateElectronilcBill,
                BillId = billInfo.BillId,
            };

            var resultBill = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "bills/store_electtronic_bill", electronicModel);
            return Ok(result);
        }

        [HttpPost("business/adjustInvoice")]
        public async Task<IActionResult> AdjustInvoice([FromBody] InvoiceModifyRequestDto requestDto)
        {
            string xml = XMLCommonFunction.GenerateInvoiceModificationXml(requestDto);

            var request = new InvoiceRequestDto()
            {
                XmlData = xml,
                Pattern = SD.EPatern,
                IKey = requestDto.Ikey
            };

            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<object>(SD.EUrl + "api/business/adjustInvoice", request, authen);
            return Ok();
        }

        [HttpPost("business/replaceInvoice")]
        public async Task<IActionResult> ReplaceInvoice([FromBody] InvoiceModifyRequestDto requestDto)
        {
            string xml = XMLCommonFunction.GenerateInvoiceModificationXml(requestDto);

            var request = new InvoiceRequestDto()
            {
                XmlData = xml,
                Pattern = SD.EPatern,
                IKey = requestDto.Ikey
            };

            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<object>(SD.EUrl + "api/business/replaceInvoice", request, authen);
            return Ok();
        }
        [HttpGet("declaration/get_detail")]

        public async Task<IActionResult> GetDeclarationDetail([FromQuery] string key)
        {
            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<DeclNormalInvDto>(SD.EUrl + "api/declaration/get_detail", new DeclarationRequestDto { Key = key }, authen);
            return Ok(result);
        }

        [HttpGet("declaration/search")]

        public async Task<IActionResult> SearchDeclaration([FromQuery] string key, [FromQuery] int option)
        {
            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<DeclNormalInvDto>(SD.EUrl + "api/declaration/search", new DeclarationRequestDto { Key = key, Option = option }, authen);
            return Ok(result);
        }

        [HttpPost("declaration/registerAndPublish")]
        public async Task<IActionResult> RegisterDeclaration([FromBody] RegistrationRequestDto requestDto)
        {
            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<string>(SD.EUrl + "api/declaration/registerAndPublish", requestDto, authen);
            return Ok(result);
        }

        [HttpPost("publish/checkInvoiceState")]
        public async Task<IActionResult> CheckInvoiceStatus([FromBody] List<string> keys)
        {
            string authen = GenerateToken("POST");
            var result = await HttpRequestsHelper.PostAuthorize<InvoiceStateResponseDto>(SD.EUrl + "api/publish/checkInvoiceState", keys, authen);
            return Ok(result);
        }

        #region Private handle methods
        private string GenerateToken(string httpMethod)
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
                return $"{signature}:{nonce}:{timestamp}:{SD.EUserName}:{SD.EPassword}";
            }
        }

        private async Task<IEnumerable<InvoiceDto>> GenerateInvoiceInformation(BillInfo billInfo)
        {
            var invoices = new List<InvoiceDto>();
            string eKey = string.Format(SD.EIKey, billInfo.BillId, DateTime.Now.Ticks);
            var customer = new CustomerResponseDto();
            var invoice = new InvoiceDto();
            var billAmount = billInfo.Payments.Sum(x => x.Amount);
            if (billInfo.CustomerId != null && billInfo.CustomerId.Value > 0)
            {
                customer = await GetCustomerInformation(billInfo.CustomerId.Value);
            }

            if (customer != null && customer.CustomerId > 0)
            {
                invoice.Buyer = string.IsNullOrEmpty(customer.CustomerName) == true ? "Khách Lẻ" : customer.CustomerName;
                invoice.CusCode = customer.CustomerCode;
                invoice.CusName = customer.CustomerName;
                invoice.CusAddress = customer.Address;
                invoice.CusPhone = customer.PhoneNumber;
            }

            invoice.Buyer = string.IsNullOrEmpty(invoice.Buyer) == true ? "Khách Lẻ" : invoice.Buyer;
            invoice.TaxAuthorityCode = SD.ETaxCode;
            invoice.Ikey = eKey;
            invoice.ArisingDate = DateTime.Now.ToString("dd/MM/yyyy");
            invoice.CurrencyUnit = "VND";
            invoice.AmountInWords = Utils.NumberToText(billAmount);
            invoice.Amount = billAmount;
            invoice.PaymentMethod = GetPaymentMethodByCode(billInfo.Payments[0].PaymentMethodCode).GetAwaiter().GetResult().PaymentMethodName;
            var products = new List<ProductInvoiceDto>();

            int totalBeforeTax = 0;
            int vatRate = 0;
            foreach (var item in billInfo.Details)
            {
                var product = await GetProductDetail(item.ProductId, item.UnitId);
                ProductInvoiceDto detail = new ProductInvoiceDto();

                detail.Code = product.ProductCode;
                detail.No = product.ProductId;
                detail.Feature = GetProductFeature(false, item.Amount).ToString();
                detail.ProdName = product.ProductName;
                detail.ProdUnit = product.UnitName;
                detail.ProdPrice = (float)product.DefaultPurchasePrice;
                detail.ProdQuantity = item.Quantity;
                detail.Discount = item.DiscountPercentage;
                detail.DiscountAmount = item.DiscountAmount;
                detail.Total = item.Amount + item.Amount * (product.Tax / 100);
                detail.VATRate = product.Tax;
                detail.VATAmount = item.Amount * (product.Tax / 100);
                detail.Amount = item.Amount;

                totalBeforeTax += item.Amount + item.Amount * (product.Tax / 100);
                vatRate += product.Tax;
                products.Add(detail);
            }

            invoice.Total = totalBeforeTax;
            invoice.VATRate = vatRate;
            invoice.VATAmount = totalBeforeTax - billAmount;
            invoice.Products = products;
            invoices.Add(invoice);

            return invoices;
        }

        private async Task<CustomerResponseDto> GetCustomerInformation(int customerId)
        {
            var result = await HttpRequestsHelper.Get<CustomerResponseDto>(SD.StorageApiUrl + "customers/get-detail?id=" + customerId);

            return result;
        }

        private async Task<ProductDetailResponseDto> GetProductDetail(int productId, int unitId)
        {
            var result = await HttpRequestsHelper.Get<ProductDetailResponseDto>(SD.StorageApiUrl + "products/get-detail-by-id-unitid?productId=" + productId + "&unitId=" + unitId);

            return result;
        }

        private async Task<PaymentMethodDto> GetPaymentMethodByCode(string code)
        {
            var result = await HttpRequestsHelper.Get<PaymentMethodDto>(SD.StorageApiUrl + "PaymentMethods/GetByCode?code=" + code);

            return result;
        }

        private int GetProductFeature(bool isSum, int amount)
        {
            int result = 1;

            if (isSum)
            {
                result = 2;
            }
            else if (amount < 0)
            {
                result = 3;
            }
            else if (amount == 0)
            {
                result = 4;
            }
            return result;
        }
        #endregion
    }
}
