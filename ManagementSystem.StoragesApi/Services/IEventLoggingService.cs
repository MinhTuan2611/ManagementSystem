using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IEventLoggingService
    {
        Task<ResponseDto> CreateEventLogAsync(EventLoggingRequestDto request);
    }
}
