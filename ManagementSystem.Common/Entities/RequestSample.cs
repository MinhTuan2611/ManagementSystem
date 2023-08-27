namespace ManagementSystem.Common.Entities
{
    public class RequestSample : BaseEntity
    {
        [Key]
        public int RequestSampleId { get; set; }
        public string RequestSampleName { get; set; }
        public int BranchId { get; set; }
        public int StorageId { get; set; }
        public List<int> RequestSampleItemIdList { get; set; }
        public int UserId { get; set; }
        public string? Note { get; set; }
    }
}