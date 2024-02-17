using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities.Bills;

public class BranchVerification
{
    [Required]
    public int BranchId { get; set; }
    [Required]
    public string VerifyPassword { get; set; }
}
