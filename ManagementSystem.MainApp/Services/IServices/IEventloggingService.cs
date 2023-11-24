using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models;

namespace ManagementSystem.MainApp.Services.IServices
{
    public interface IEventloggingService
    {
        Task<ResponseDto?> Create(EventLoggingRequestDto request);
    }
}
