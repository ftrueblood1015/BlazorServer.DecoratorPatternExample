using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Services;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;
using BlazorServer.DecoratorPatternExample.Services.Holidays;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public class HolidayLoggingService : LoggingServiceDecoratorBase<Holiday, IHolidayService>, IHolidayLoggingService
    {
        public HolidayLoggingService(IServiceBase<Holiday> service, IEventLoggerService logger) : base(service, logger)
        {
        }
    }
}
