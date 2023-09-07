using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IRequestSampleService
    {
        IEnumerable<RequestSample> GetListRequestSamples();

        RequestSample GetRequestSampleById(int requestId);

        RequestSample CreateRequestSample(RequestSample request);

        bool UpdateRequestSample(int requestId, RequestSampleModel request);

        bool DeleteRequestSample(int requestId);

    }
}
