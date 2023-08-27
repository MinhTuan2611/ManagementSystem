namespace ManagementSystem.Common.Models
{
    public class RequestSampleItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public string? Note { get; set; }
    }
    public class RequestSampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RequestedBranch Branch { get; set; }
        public RequestedStorage Storage { get; set; }
        public RequestSampleItemModel Items { get; set; }
        public string? Note { get; set; }
    }
    public class RequestedBranch
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? BranchContactName { get; set; }
        public string? BranchPhone { get; set; }
    }

    public class RequestedStorage
    {
        public int StorageId { get; set; }
        public string? StorageName { get; set; }
        public string? StorageAddress { get; set; }
        public string? StoragePhone { get; set; }
    }
}
