using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
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

        private async Task<InvoiceDto> GenerateInvoiceInformation(BillInfo billInfo)
        {
            var invoice = new InvoiceDto();

            var customer = new CustomerResponseDto();

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
            
            return invoice ;
        }

        private async Task<CustomerResponseDto> GetCustomerInformation(int customerId) {
            ResponseModel<CustomerResponseDto> response = new ResponseModel<CustomerResponseDto>();
            var result = await HttpRequestsHelper.Get<CustomerResponseDto>(SD.StorageApiUrl + "customers/get-detail?id=" + customerId);

           return result;
        }
        #endregion
    }
}
