﻿using ManagementSystem.Common.Models;
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
        [MaxLength(128)]
        public string AccountCode { get; set; }
        [MaxLength(128)]
        public string AccountName { get; set; }
        public int? AccountParentId { get; set; }
        public HasAccountItemStatus? HasAccountItem { get; set; }
        public HasAccountItemStatus? HasCosting { get; set; }
        public BalanceType? BalanceType { get; set; }
        public int AccountRank { get; set; }
    }
}
