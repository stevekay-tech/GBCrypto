using System;
using System.Threading.Tasks;
using GloboCrypto.Models.Notifications;
using GloboCrypto.WebAPI.Services.Data;

namespace GloboCrypto.WebAPI.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly ILocalDbService LocalDb;

        public NotificationService(ILocalDbService localDb)
        {
            LocalDb = localDb;
        }

        public Task CheckAndNotifyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationSubscription> SubscribeAsync(string userId, NotificationSubscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubscription(string userId, string coinIds)
        {
            throw new NotImplementedException();
        }
    }
}
