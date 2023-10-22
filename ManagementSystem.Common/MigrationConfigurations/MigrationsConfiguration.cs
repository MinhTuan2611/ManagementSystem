using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.MigrationConfigurations
{
    public class MigrationsConfiguration
    {
        public List<string> ExcludedTableNames { get; } = new List<string>();
        public List<Type> ExcludedTableTypes { get; } = new List<Type>();
    }
}
