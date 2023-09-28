using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos.RequestSamples;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IRequestSampleService
    {
        IEnumerable<ResponseSampleDto> GetListRequestSamples();

        Task<ResponseSampleDto> GetRequestSampleById(int requestId);

        Task<RequestSample> CreateRequestSample(RequestSample request);

        Task<bool> UpdateRequestSample(RequestSample requestSample);

        Task<bool> DeleteRequestSample(int requestId, int userId);

    }
}
