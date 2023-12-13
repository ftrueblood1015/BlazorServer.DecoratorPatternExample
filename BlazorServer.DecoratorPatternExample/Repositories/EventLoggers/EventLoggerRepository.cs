using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Infrastructure;

namespace BlazorServer.DecoratorPatternExample.Repositories.EventLoggers
{
    public class EventLoggerRepository : RepositoryBase<EventLogger, DecoratorPatternContext>, IEventLoggerRepository
    {
        public EventLoggerRepository(DecoratorPatternContext context) : base(context)
        {
        }
    }
}
