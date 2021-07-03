using System;
using System.Threading.Tasks;
using GloboCrypto.Models.Notifications;

namespace GloboCrypto.WebAPI.Services.Notifications
{
    public interface INotificationService
    {
        Task CheckAndNotifyAsync();
        Task<NotificationSubscription> SubscribeAsync(string userId, NotificationSubscription subscription);
        Task UpdateSubscription(string userId, string coinIds);
    }
}
