using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos.Users
{
    public class UserChangePasswordRequestDto
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public int UserId { get; set; }
    }
}
