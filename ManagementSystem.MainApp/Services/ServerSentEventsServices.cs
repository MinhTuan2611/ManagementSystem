using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Options;

namespace ManagementSystem.MainApp.Services
{
    public class ServerSentEventsServices : ServerSentEventsService, IServerSentEventsServices
    {
        public ServerSentEventsServices(IOptions<ServerSentEventsServiceOptions<ServerSentEventsServices>> options)
            : base(options.ToBaseServerSentEventsServiceOptions())
        { }
        public async Task SendMessageAsync(string actionType, string eventId, string message, bool isCompleted = false)
        {
            if (isCompleted)
            {
                await SendEventAsync(new ServerSentEvent()
                {
                    Id = eventId,
                    Type = actionType,
                    Data = new List<string>() { "Completed_" + message }
                });
            }
            else
            {
                await SendEventAsync(new ServerSentEvent()
                {
                    Id = eventId,
                    Type = actionType,
                    Data = new List<string>() { message }
                });
            }
        }
    }
}
