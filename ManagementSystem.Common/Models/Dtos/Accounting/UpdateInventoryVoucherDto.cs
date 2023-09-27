using ManagementSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateInventoryVoucherDto
    {
        public int DocummentNumber { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int ShiftId { get; set; }
        public int? BrandId { get; set; }
        public string PurchasingRepresentive { get; set; }
        public string RepresentivePhone { get; set; }
        public string ReasonFor { get; set; }

        public int Price { get; set; }
        public int DebitAccount { get; set; }
        public int CreditAccount { get; set; }
        public int TotalMoneyBeforeTax { get; set; }
        public int DebitAccountMoney { get; set; }
        public int CreditAccountMoney { get; set; }
        public int PaymentDiscountAccount { get; set; }
        public int PaymentDiscountMoney { get; set; }
        public int TaxAccount { get; set; }
        public int TaxMoney { get; set; }

        public string Note { get; set; } = "";
        public int PaymentMethodId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public List<InventoryVoucherDetailDto> Details { get; set; }
        public List<int> PaymentMethodIds { get; set; }
    }
}
