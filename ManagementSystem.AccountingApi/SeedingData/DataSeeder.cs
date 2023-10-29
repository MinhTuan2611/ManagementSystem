using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Entities;

namespace ManagementSystem.AccountingApi.SeedingData
{
    public class DataSeeder
    {
        public static void SeedData(AccountingDbContext context)
        {
            try
            {
                #region Init Document Group
                if (!context.DocumentGroups.Any())
                {
                    var documents = new List<DocumentGroup>()
                    {
                        new DocumentGroup()
                        {
                            GroupId = 1,
                            GroupName = "Manual",
                        },
                        new DocumentGroup()
                        {
                            GroupId = 2,
                            GroupName = "AutoGenerate",
                        }
                    };

                    context.DocumentGroups.AddRange(documents);
                    context.SaveChanges();
                }

                #endregion
            }
            catch
            {
            }
        }
    }
}
