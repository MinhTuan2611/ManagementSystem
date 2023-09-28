
using ManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.EmployeesApi.Data
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
    }
}
