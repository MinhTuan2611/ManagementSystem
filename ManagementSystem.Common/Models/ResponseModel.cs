using ManagementSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    public class ResponseModel
    {
        public string Status { get ; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class LsBranchRes : ResponseModel
    {
        public List<Branch>? Branches { get; set; }
    }

    public class LsStorageRes : ResponseModel
    {
        public List<Storage>? Storages { get; set; }
    }

    public class LsRecTransRes : ResponseModel
    {
        public List<RecTransInfo>? RecTrans { get; set; }
    }

    public class LsTypeOfAccountingsRes : ResponseModel
    {
        public List<TypesOfAccountsInfo>? Data { get; set; }
    }

    public class LsSuppllerRes : ResponseModel
    {
        public List<Supplier>? Data { get; set; }
    }

    public class ResponseModel<T>
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public List<T>? Data { get; set; }
    }
}
