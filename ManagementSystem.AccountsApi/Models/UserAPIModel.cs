namespace ManagementSystem.AccountsApi.Models
{
    public class UserAPIModel
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
    }
}
