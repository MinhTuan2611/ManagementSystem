using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models
{
    [Serializable]
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            if (PageSize <= 0)
            {
                PageSize = 10;
            }
        }
        public IDictionary<string, object> Criterias { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
