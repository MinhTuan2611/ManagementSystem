using System.Collections.Generic;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IRequestService
    {
        IEnumerable<RequestInfo> GetListRequests();
        Request GetRequestById(int requestId);
        Request CreateRequest(RequestModel request);
        bool UpdateRequest(int requestId, Request updatedRequest);
        bool DeleteRequest(int requestId);
    }
}