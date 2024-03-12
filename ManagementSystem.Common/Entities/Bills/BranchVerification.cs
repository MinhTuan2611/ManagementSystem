using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities.Bills;

public class BranchVerification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int BranchId { get; set; }
    [Required]
    [MaxLength(500)]
    public string VerifyPassword { get; set; }
}
