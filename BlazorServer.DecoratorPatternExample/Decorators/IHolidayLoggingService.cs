using BlazorServer.DecoratorPatternExample.Domain.Models;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public interface IHolidayLoggingService : ILoggingServiceDecoratorBase<Holiday>
    {

    }
}
