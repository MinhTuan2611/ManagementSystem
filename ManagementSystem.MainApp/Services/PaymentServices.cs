using ManagementSystem.Common.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ManagementSystem.MainApp.Services
{
    public class PaymentServices : IPaymentServices
    {
        private static readonly HttpClient client = new HttpClient();
        public PaymentServices()
        {
            
        }
        public async Task<QuickPayResponse> MomoCreatePayment(int orderId, int amount)
        {
            string accessKey = "klm05TvNBzhg7h7j";
            string secretKey = "at67qH6mk8w5Y1nAyMoYKMWACiEi2bsa";

            QuickPayResquest request = new QuickPayResquest();
            request.orderInfo = "pay with MoMo";
            request.partnerCode = "MOMOBKUN20180529";
            request.redirectUrl = ""; 
            request.ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            request.amount = amount;
            request.orderId = "FM-"+ orderId;
            request.requestId = "FM-" + orderId;
            request.extraData = "";
            request.lang = "vi";
            request.requestType = "captureWallet";

            var rawSignature = "accessKey=" + accessKey + "&amount=" + request.amount + "&extraData=" + request.extraData + "&ipnUrl=" + request.ipnUrl + "&orderId=" + request.orderId + "&orderInfo=" + request.orderInfo + "&partnerCode=" + request.partnerCode + "&redirectUrl=" + request.redirectUrl + "&requestId=" + request.requestId + "&requestType=" + request.requestType;
            request.signature = getSignature(rawSignature, secretKey);

            StringContent httpContent = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");
            var quickPayResponse = await client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);
            var contents = quickPayResponse.Content.ReadAsStringAsync().Result;
            var result = JsonSerializer.Deserialize<QuickPayResponse>(contents);
            return result;
        }
        private static String getSignature(String text, String key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
