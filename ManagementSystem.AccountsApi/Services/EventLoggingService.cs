using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.EmployeesApi.Data;

namespace ManagementSystem.AccountsApi.Services
{
    public class EventLoggingService : IEventLoggingService
    {
        private readonly string _path = string.Empty;
        private readonly AccountsDbContext _context;
        private ResponseDto _response;

        public EventLoggingService(AccountsDbContext context)
        {
            _path = @"C:\\Logs\\Account\\EventLogging\\";
            _context = context;
            _response = new ResponseDto();
        }
        public async Task<ResponseDto> CreateEventLogAsync(EventLoggingRequestDto request)
        {
            try
            {
                _context.ActivityLog.Add(new ActivityLog
                {
                    UserId = request.UserId.Value,
                    Action = request.MessageLogging,
                    Source = request.Source,
                    DateModified = DateTime.Now
                });

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function CreateEventLogAsync: " + ex.Message, _path);

                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;

        }
    }
}
