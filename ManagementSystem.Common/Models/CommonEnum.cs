using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public enum ActiveStatus
    {
        Active,
        Inactive
    }
    public enum ProductTypes
    {
        Product,
        Combo
    }
    public enum HasAccountItemStatus
    {
        Unchecked,
        Indeterminate
    }

    public enum BalanceType
    {
        [Description("Bên nợ")]
        DebitSide,
        [Description("Bên có")]
        CreditSide,
        [Description("Lưỡng tính")]
        DoubleEntry
    }
}
