using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Entities
{
    public class Recordingtransaction : BaseEntity
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string ReasonGroup { get; set; }
        public string ReasonCode { get; set;}
        public string ReasonName { get; set;}
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public string? ExpenseItem { get; set; }
        public string? Note { get; set; }
    }
}
