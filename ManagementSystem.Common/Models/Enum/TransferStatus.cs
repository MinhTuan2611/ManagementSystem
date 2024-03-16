using System.ComponentModel;

public enum TransferStatus
{
    [Description("Tạo phiếu")]
    Created = 1,
    [Description("Đang vận chuyển")]
    Transporting = 2,
    [Description("Nhận hàng")]
    Receive = 3,
}