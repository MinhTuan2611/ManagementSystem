namespace ManagementSystem.Common.Models.Dtos
{
    public class LegerExcelView
    {
        //[DisplayName("Ngày")]
        public DateTime TransactionDate { get; set; }
        public string? DepositAccount { get; set; }
        public string? CreditAccount { get; set; }
        public string? DoccumentType { get; set; }
        public int? DoccumentNumber { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public long? Amount { get; set; }
    }
}
