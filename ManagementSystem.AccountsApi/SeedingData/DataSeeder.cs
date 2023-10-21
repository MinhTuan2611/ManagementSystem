using ManagementSystem.Common.Entities;
using ManagementSystem.EmployeesApi.Data;

namespace ManagementSystem.AccountsApi.SeedingData
{
    public class DataSeeder
    {
        public static void SeedData(AccountsDbContext dbContext)
        {
            #region Init Employee Shift
            var a = dbContext.EmployeeShifts.ToArray();
            if (!dbContext.EmployeeShifts.Any())
            {
                var employeeShift = new List<EmployeeShift>()
                {
                    new EmployeeShift()
                    {
                        ShiftName = "Ca Sáng",
                        StartHour = 6,
                        StartMinute = 0,
                        EndHour = 12,
                        EndMinute = 0
                    },
                    new EmployeeShift()
                    {
                        ShiftName = "Ca Chiều",
                        StartHour = 12,
                        StartMinute = 0,
                        EndHour = 6,
                        EndMinute = 0
                    }
                };

                dbContext.EmployeeShifts.AddRange(employeeShift);
                dbContext.SaveChanges();
            }
            #endregion
        }
    }
}
