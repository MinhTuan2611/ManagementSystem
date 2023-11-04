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
        public IDictionary<string, object> Criterias { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class MultipleSearchResult
    {
        public List<CustomerResponseDto> CustomerResponses { get; set; }
        public IList<ProductListResponse> ProductResponses { get; set; }
    }
}
