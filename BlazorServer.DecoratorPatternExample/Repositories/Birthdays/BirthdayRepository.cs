using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Infrastructure;

namespace BlazorServer.DecoratorPatternExample.Repositories.Birthdays
{
    public class BirthdayRepository : RepositoryBase<Birthday, DecoratorPatternContext>, IBirthdayRepository
    {
        public BirthdayRepository(DecoratorPatternContext context) : base(context)
        {
        }
    }
}
