using System.Collections.Generic;
using ManagementSystem.Common.Entities;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IRequestService
    {
        IEnumerable<Request> GetListRequests();
        Request GetRequestById(int requestId);
        Request CreateRequest(Request request);
        bool UpdateRequest(int requestId, Request updatedRequest);
        bool DeleteRequest(int requestId);
    }
}