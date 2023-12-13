using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Services;
using BlazorServer.DecoratorPatternExample.Services.Anniversaries;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public class AnniversaryLoggingService : LoggingServiceDecoratorBase<Anniversary, IAnniversaryService>, IAnniversaryLoggingService
    {
        public AnniversaryLoggingService(IServiceBase<Anniversary> service, IEventLoggerService logger) : base(service, logger)
        {
        }
    }
}
