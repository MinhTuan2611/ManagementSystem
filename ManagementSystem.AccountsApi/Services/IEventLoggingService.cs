using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IEventLoggingService
    {
        Task<ResponseDto> CreateEventLogAsync(EventLoggingRequestDto request);
    }
}
