using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Recordingtransaction : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string DocumentType { get; set; }
        [MaxLength(128)]
        public string ReasonGroup { get; set; }
        [MaxLength(128)]
        public string ReasonCode { get; set;}
        [MaxLength(128)]
        public string ReasonName { get; set;}
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        [MaxLength(500)]
        public string? ExpenseItem { get; set; }
        [MaxLength(1000)]
        public string? Note { get; set; }
    }
}
