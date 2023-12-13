using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories;
using BlazorServer.DecoratorPatternExample.Repositories.Holidays;

namespace BlazorServer.DecoratorPatternExample.Services.Holidays
{
    public class HolidayService : ServiceBase<Holiday, IHolidayRepository>, IHolidayService
    {
        public HolidayService(IRepositoryBase<Holiday> repo) : base(repo)
        {
        }
    }
}
