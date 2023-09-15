using System.Collections.Generic;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IRequestService
    {
        IEnumerable<RequestInfo> GetListRequests();
        RequestModel GetRequestById(int requestId);
        Request CreateRequest(RequestModel request, int userId);
        bool UpdateRequest(int requestId, RequestModel updatedRequest, int userId);
        bool DeleteRequest(int requestId);
    }
}