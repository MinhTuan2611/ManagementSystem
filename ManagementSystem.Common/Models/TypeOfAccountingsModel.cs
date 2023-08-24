using ManagementSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class TypesOfAccountsInfo
    {
        public int? AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public int? AccountParentId { get; set; }
        public HasAccountItemStatus? HasAccountItem { get; set; }
        public HasAccountItemStatus? HasCosting { get; set; }
        public BalanceType? BalanceType { get; set; }
        public int AccountRank { get; set; }
    }
}
