using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IEventLoggingService
    {
        Task<ResponseDto> CreateEventLogAsync(EventLoggingRequestDto request);
    }
}
