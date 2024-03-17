using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class DeclNormalInvDto
    {
        public bool HasCode { get; set; }
        public bool NoCode { get; set; }
        public bool DifficultLocal { get; set; }
        public bool SuggestionAgency { get; set; }
        public bool ViaTVAN { get; set; }
        public bool InvTransfer { get; set; }
        public bool ReportTransfer { get; set; }
        public bool VatInv { get; set; }
        public bool SaleInv { get; set; }
        public bool SalePublicPropertyInv { get; set; }
        public bool SaleNationalReserveInv { get; set; }
        public bool OtherInv { get; set; }
        public bool OutStockInv { get; set; }
        public bool? CashRegister { get; set; }
        public bool? CashRegisterInfo { get; set; }
    }
}
