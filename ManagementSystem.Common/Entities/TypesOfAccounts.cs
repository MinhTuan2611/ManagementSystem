using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class TypesOfAccounts : BaseEntity
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public int AccountParentId { get; set; }
        public int IsLiability { get; set; }
        public int LiabilityType { get; set; }
        public int AccountRank { get;}
    }
}
