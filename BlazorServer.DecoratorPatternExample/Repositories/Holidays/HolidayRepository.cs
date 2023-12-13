using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Infrastructure;

namespace BlazorServer.DecoratorPatternExample.Repositories.Holidays
{
    public class HolidayRepository : RepositoryBase<Holiday, DecoratorPatternContext>, IHolidayRepository
    {
        public HolidayRepository(DecoratorPatternContext context) : base(context)
        {
        }
    }
}
