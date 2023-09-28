using Lib.AspNetCore.ServerSentEvents;
using ManagementSystem.Common.Models;

namespace ManagementSystem.MainApp.Services
{
    public interface INotificationsServices : IServerSentEventsService
    {
        public Task SendMessageAsync(string typeId, string eventId, string message, bool isCompleted = false);
    }
}
