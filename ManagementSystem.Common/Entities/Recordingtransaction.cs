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
        public string TypeOfVoucherCode { get; set; }
        public string TypeOfVoucherName { get; set;}
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
    }
}
