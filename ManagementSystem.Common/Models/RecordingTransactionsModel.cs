using ManagementSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class RecTransInfo
    {
        public int? Id { get; set; }
        public string DocumentType { get; set; }
        public string ReasonGroup { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
        public string? ExpenseItem { get; set; }
        public ActiveStatus? Status { get; set; }
        public string? Note { get; set; }
    }
    public class RecTransRequest
    {
        public int? UserId { get; set; }
        public int? RecTransId { get; set; }
    }

    public class ResTransModel : RecTransRequest
    {
        public RecTransInfo RecTrans { get; set; }
    }
}
