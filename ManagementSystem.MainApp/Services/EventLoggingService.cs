using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Services.IServices;
using ManagementSystem.MainApp.Utility;

namespace ManagementSystem.MainApp.Services
{
    public class EventLoggingService : IEventloggingService
    {
        private readonly IBaseService _baseService;

        public EventLoggingService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public Task<ResponseDto?> Create(EventLoggingRequestDto request)
        {
            string path = string.Empty;

            if (request.Source == "StoragesApi")
            {
                path = SD.StorageApiUrl;
            }
            else if (request.Source == "AccountingApi")
            {
                path = SD.AccountingApiUrl;
            }
            else
            {
                path = SD.AccountApiUrl;
            }

            return _baseService.SendAsync(new Models.RequestDto()
            {
                Url = path + "EventLogging/create",
                Data = request,
                ApiType = SD.ApiType.POST
            });
        }
    }
}
