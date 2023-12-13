using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Infrastructure;

namespace BlazorServer.DecoratorPatternExample.Repositories.Anniversaries
{
    public class AnniversaryRepository : RepositoryBase<Anniversary, DecoratorPatternContext>, IAnniversayRepository
    {
        public AnniversaryRepository(DecoratorPatternContext context) : base(context)
        {
        }
    }
}
