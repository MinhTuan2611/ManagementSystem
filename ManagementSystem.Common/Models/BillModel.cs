using ManagementSystem.Common.Entities;

namespace ManagementSystem.Common.Models
{
    public class ListBillResponse
    {
        public int BillId { get; set; }
        public int TotalAmount { get; set; } = 0;
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class BillInfo
    {
        public int? BillId { get; set; }
        public int totalAmount { get; set; } = 0;
        public int totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? EmployeeShiftId { get; set; }
        public int? BrandId { get; set; }
        public List<BillDetailInfo> Details { get; set; }
        public List<PaymentDetail> Payments { get; set; }

    }
    public class BillDetailInfo
    {
        public int? Id { get; set; }
        public int? BillId { get; set; }
        public int ProductId { get; set; } = 0;
        public string? ProductName { get; set; }
        public int UnitId { get; set; }
        public string? UnitName { get; set; }
        public int DiscountAmount { get; set; } = 0;
        public int DiscountPercentage { get; set; } = 0;
        public bool DiscountByPercentage { get; set; } = false;
        public int Quantity { get; set; } = 0;
        public int Amount { get; set; } = 0;
    }
    public class PaymentDetail
    {
        public int? Id { get; set; }
        public int? BillId { get; set; } = 0;
        public int? PaymentMethodId { get; set; }

        public string PaymentMethodCode { get; set; }
        public string? PaymentMethodName { get; set; }
        public int Amount { get; set; } = 0;
    }
}
