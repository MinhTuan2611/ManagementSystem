using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Models;

namespace ManagementSystem.MainApp.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto request);
    }
}
