using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Common.Entities
{
    public class UserBranch
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int? BranchId { get; set; }

        public User User { get; set; }
    }
}
