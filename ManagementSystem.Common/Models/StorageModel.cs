namespace ManagementSystem.Common.Models
{
    public class StorageInfo
    {
        public string StorageCode { get; set; }
        public string StorageName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? BranchId { get; set; }
    }

    public class StorageRequest
    {
        public int? UserId { get; set; }
        public int StorageId { get; set; }
    }

    public class UpdateStorageModel : StorageRequest
    {
        public StorageInfo Storage { get; set; }
    }
}
