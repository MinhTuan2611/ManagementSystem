
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;
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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<UserBranch> UserBranchs { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        
        // Response query result
        public DbSet<UserBrandDto> UserBrandDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserBrandDto>().ToTable(nameof(UserBrandDto), x => x.ExcludeFromMigrations());
        }
    }
}
