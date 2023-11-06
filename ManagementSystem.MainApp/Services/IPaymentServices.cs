using Lib.AspNetCore.ServerSentEvents;
using ManagementSystem.Common.Models;

namespace ManagementSystem.MainApp.Services
{
    public interface IPaymentServices
    {
        public Task<QuickPayResponse> MomoCreatePayment(int orderId, int amount);
    }
}
