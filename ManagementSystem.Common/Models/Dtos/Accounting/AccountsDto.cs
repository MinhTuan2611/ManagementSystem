using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Common.Models.Dtos
{
    [Keyless]
    public class AccountsDto
    {
        public string? CreditAccount { get; set; }
        public string? DebitAccount { get; set; }
    }
}
