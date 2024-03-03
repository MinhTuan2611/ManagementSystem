namespace ManagementSystem.Common.Models
{
    public class BranchInfo
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VefificationPassword { get; set; }
    }
    public class BranchRequest
    {
        public int? UserId { get; set; }
        public int BranchId { get; set; }
    }

    public class UpdateBranchModel : BranchRequest
    {
        public BranchInfo Branch { get; set; }
    }

    
}
