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
}
