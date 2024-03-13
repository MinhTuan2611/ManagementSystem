using System.ComponentModel;

public enum Status
{
    [Description("Chờ duyệt")]
    Pending = 1,
    [Description("Chờ xử lý")]
    Waiting = 2,
    [Description("Đã duyệt")]
    Approved = 3,
    [Description("Từ chối")]
    Reject = 4,
}