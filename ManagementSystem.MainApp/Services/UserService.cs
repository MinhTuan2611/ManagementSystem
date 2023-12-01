using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Users;
using ManagementSystem.MainApp.Models;
using ManagementSystem.MainApp.Services.IServices;
using ManagementSystem.MainApp.Utility;

namespace ManagementSystem.MainApp.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public Task<ResponseDto?> ChangePassword(UserChangePasswordRequestDto requestDto)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                Url = SD.AccountApiUrl + "Users/change_password",
                ApiType = SD.ApiType.POST,
                Data = requestDto
            });
        }
    }
}
