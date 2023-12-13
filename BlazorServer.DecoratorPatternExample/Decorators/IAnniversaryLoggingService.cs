using BlazorServer.DecoratorPatternExample.Domain.Models;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public interface IAnniversaryLoggingService : ILoggingServiceDecoratorBase<Anniversary>
    {

    }
}
