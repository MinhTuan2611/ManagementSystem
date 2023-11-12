using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class DeclarationDetailResponseDto
    {
        public int ID { get; set; }
        public string? FormPattern { get; set; }
        public string? Name { get; set; }
        public int Method { get; set; }
        public string? TaxCode { get; set; }
        public string Payer { get; set; }
        public string TaxAuthorName { get; set; }
        public string ContractPerson { get; set; }
        public string ContractAddress { get; set; }
        public int DelegateType { get; set; }
        public string Phone { get; set; }
        public string EstablishNo { get; set; }
        public DateTime? EstablishDate { get; set; }
        public string? EstablishAuthor { get; set; }
        public string? IdentityNo { get; set; }
        public string? IssuedOn { get; set; }
        public string? IssuedAt { get; set; }
        public string CreatePlace { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? MPTransCode { get; set; }
        public int TCTCheckStatus { get; set; }
        public string? Message { get; set; }
        public string CompanyName { get; set; }
        public int DeclarationType { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public bool IsCashRegister { get; set; }
        public string? TaxAuthorityCode { get; set; }

        public DeclNormalInvDto? DeclNormalInv { get; set; }

        public List<DeclarationSignatureDto>? DeclarationSignature {  get; set; }
    }
}
