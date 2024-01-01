namespace ManagementSystem.MainApp.Utility
{
    public class SD
    {
        public static string StorageApiUrl { get; set; }
        public static string AccountApiUrl { get; set; }
        public static string AccountingApiUrl { get; set; }
        public static string MainApiUrl { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static string EIKey { get; set; }
        public static string EPatern { get; set; }
        public static string ETaxCode { get; set; }
        public static string EUserName { get; set; }
        public static string EPassword { get; set; }
        public static string EUrl { get; set; }
    }
}
