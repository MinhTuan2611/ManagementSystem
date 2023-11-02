namespace ManagementSystem.Common.Models.Dtos
{
    public class NewCreditVoucherRequestDto
    {
        public int? CustomerId { get; set; }
        public string? ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int UserId { get; set; }
        public int? BillId { get; set; }
        public string? PaymentMethodCode { get; set; }
        public int? GroupId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductId { get; set; }

    }
}
