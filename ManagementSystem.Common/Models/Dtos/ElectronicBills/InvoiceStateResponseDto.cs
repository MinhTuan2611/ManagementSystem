using Newtonsoft.Json;

namespace ManagementSystem.Common.Models.Dtos.ElectronicBills
{
    public class InvoiceStateResponseDto
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public string ErrorCode { get; set; }

        public Data Data { get; set; }
    }

    public class KeyInvoiceMsg
    {
        [JsonProperty("ikey1")]
        public string IKey1 { get; set; }

        [JsonProperty("ikey2")]
        public string IKey2 { get; set; }
    }

    public class Data
    {
        [JsonProperty("KeyInvoiceMsg")]
        public KeyInvoiceMsg KeyInvoiceMsg { get; set; }
    }
}
