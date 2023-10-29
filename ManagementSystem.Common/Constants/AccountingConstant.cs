﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Constants
{
    public static class AccountingConstant
    {
        public const string ReceiptType = "THU";
        public const string InventoryDeliveryDocummentType = "XUAT";
        public const string CreditVoucher = "PHIEU CO";
        public const string DebitVoucher = "PHIEU NO";
        public const string OtherAccountEntryType = "BUT TOAN KHAC";
        public const string PaymentVoucherType = "CHI";

        public const string XBAReason = "XBA";
        public const string CCHReason = "CCH";
        public const string ReceiptReason = "Thu Tiền Xuất Hàng {0}. ";
        public const string CreditVoucherType = "BAOCO";
        public const string DebitVoucherType = "BAONO";

        public const int AutoGenerateDocumentGroup = 2;
    }
}
