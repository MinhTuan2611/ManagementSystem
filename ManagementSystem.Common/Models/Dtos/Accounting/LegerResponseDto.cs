using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class LegerResponseDto
    {
        public string TransactionDate { get; set; }
        public int DebitAccount { get; set; }
        public int CreitAccount { get; set; }
        public int DoccumentNumer { get; set; }
        public string DocumentType { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int TotalMoney { get; set; }
    }
}
