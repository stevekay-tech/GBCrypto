using System.Threading.Tasks;
using GloboCrypto.Models.Notifications;
using GloboCrypto.WebAPI.Services.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboCrypto.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService NotificationService;

        public NotificationController(INotificationService notificationService)
        {
            NotificationService = notificationService;
        }

        [HttpPut("subscribe")]
        public async Task<NotificationSubscription> Subscribe(string userId, NotificationSubscription subscription)
        {
            //var userId = GetUserId();
            return await NotificationService.SubscribeAsync(userId, subscription);
        }

        [HttpGet("update-subscription")]
        public async Task UpdateSubscription(string userId, string coinIds)
        {
            //var userId = GetUserId();
            await NotificationService.UpdateSubscriptionAsync(userId, coinIds);
        }

        [HttpGet("check-and-notify")]
        public async Task CheckAndNotify()
        {
            await NotificationService.CheckAndNotifyAsync();
        }

        private string GetUserId()
        {
            return User.Identity.Name;
        }

    }
}
