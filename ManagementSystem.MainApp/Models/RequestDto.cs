using static ManagementSystem.MainApp.Utility.SD;

namespace ManagementSystem.MainApp.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }

    }
}
