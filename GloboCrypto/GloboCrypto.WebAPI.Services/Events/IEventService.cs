using GloboCrypto.WebAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GloboCrypto.WebAPI.Services.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventLogEntry>> GetAllEvents();
        Task<IEnumerable<EventLogEntry>> GetEventByType(EventLogEntryType entryType);
        Task<IEnumerable<EventLogEntry>> GetEventsByTypes(IEnumerable<EventLogEntryType> entryTypes);
        Task LogAuthentication(string userId);
        Task LogSubscription(string userId);
        Task LogSubscriptionUpdate(string userId);
        Task LogError(string message, Exception ex);
        Task LogGameUpdateNotification(string userId, long gameId);
        Task LogInformation(string message);
        Task<IEnumerable<EventLogEntry>> QueryEvents(Expression<Func<EventLogEntry, bool>> query);
        Task ClearAllEvents();
        Task DeleteEvent(int id);
    }
}
