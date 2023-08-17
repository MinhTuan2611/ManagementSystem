using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserRegister
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Roles { get; set; }
    }

    public class UserInformation
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Roles { get; set; }
    }

    public class UpdateUserModel
    {
        public int UserId { get; set; }
        public UserInformation UserEntity { get; set; }
    }

    public class TokenRes
    {
        public string Token { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public string Username { get; set; }
    }
}
