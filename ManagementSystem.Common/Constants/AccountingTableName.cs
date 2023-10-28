using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.Common
{
    public static class AccountingTableName
    {
        public static List<string> GenerateExcludedTableName()
        {
            return new List<string>()
            {
                //"InventoryVoucherResponseDto",
                //"InventoryVoucherDetailResponseDto",
                //"ReceiptResponseDto",
                //"ProductResponseDto",
                //"PaymentMethodResponseDto",
                //"UnitResponseDto",
                //"ProductStorageInformationDto",
                //"LegerResponseDto",
                //"PaymentVoucherResponseDto",
                //"OtherAccountEntryResponseDto",
                //"BillPaymentDetailResponseDto",
                //"ShiftEndResponseDto",
                //"ShiftHandoverResponseDto",
                //"ShiftReportResponseDto",
                //"AccountsDto",
                //"ShiftEndReportView"

            };
        }
        public static List<Type> GenerateDynamicResponseDbSet()
        {
            return new List<Type>()
            {
               //typeof(InventoryVoucherResponseDto),
               // typeof(InventoryVoucherDetailResponseDto),
               // typeof(ReceiptResponseDto),
               // typeof(ProductResponseDto),
               // typeof(PaymentMethodResponseDto),
               // typeof(UnitResponseDto),
               // typeof(LegerResponseDto),
               // typeof(ProductStorageInformationDto),
               // typeof(PaymentVoucherResponseDto),
               // typeof(BillPaymentDetailResponseDto),
               // typeof(OtherAccountEntryResponseDto),
               // typeof(ShiftEndResponseDto),
               // typeof(ShiftHandoverResponseDto),
               // typeof(ShiftReportResponseDto),
               // typeof(AccountsDto),
                typeof(ScalarResult<int>),
                typeof(ScalarResult<string>),
                typeof(PaymentMethodDto),
                typeof(AccountsDto),
                typeof(RecTransInfoResponseDto),
                typeof(CreditVoucherResponseDto),
                typeof(DebitVoucherResponseDto),
                typeof(DocumentGroupResponseDto)
            };
        }
    }
}
