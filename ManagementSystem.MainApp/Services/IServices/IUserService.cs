using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Users;

namespace ManagementSystem.MainApp.Services.IServices
{
    public interface IUserService
    {
        Task<ResponseDto?> ChangePassword(UserChangePasswordRequestDto requestDto);
    }
}
