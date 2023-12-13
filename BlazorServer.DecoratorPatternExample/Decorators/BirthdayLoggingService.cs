using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Services;
using BlazorServer.DecoratorPatternExample.Services.Birthdays;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public class BirthdayLoggingService : LoggingServiceDecoratorBase<Birthday, IBirthdayService>, IBirthdayLoggingService
    {
        public BirthdayLoggingService(IServiceBase<Birthday> service, IEventLoggerService logger) : base(service, logger)
        {
        }
    }
}
