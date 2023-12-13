using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories;
using BlazorServer.DecoratorPatternExample.Repositories.EventLoggers;

namespace BlazorServer.DecoratorPatternExample.Services.EventLoggers
{
    public class EventLoggerService : ServiceBase<EventLogger, IEventLoggerRepository>, IEventLoggerService
    {
        public EventLoggerService(IRepositoryBase<EventLogger> repo) : base(repo)
        {
        }
    }
}
