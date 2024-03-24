using System.ComponentModel;

namespace ManagementSystem.Common.Models.Enum;

public enum RefundAction
{
    [Description("Hoàn tiền")]
    HOANTIEN = 1,
    [Description("Đổi Trả Hàng")]
    DOIMOI = 2
}

public enum RefundReason
{
    [Description("Hư hỏng")]
    HU = 1,
    [Description("Đổi nhu cầu")]
    DOI = 2
}