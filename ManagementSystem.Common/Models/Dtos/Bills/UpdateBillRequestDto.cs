﻿namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateBillRequestDto
    {
        public int BillId { get; set; }
        public int totalAmount { get; set; } = 0;
        public int totalPaid { get; set; } = 0;
        public int totalChange { get; set; } = 0;
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public int? BranchId { get; set; }
        public int? ShiftId { get; set; }
        public List<UpdateBillDetailRequestDto> BillDetail { get; set; }
        public List<UpdateBillPaymentMethodRequestDto> PaymentMethods { get; set; }

    }
}
