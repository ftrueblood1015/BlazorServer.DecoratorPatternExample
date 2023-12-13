using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories;
using BlazorServer.DecoratorPatternExample.Repositories.Anniversaries;

namespace BlazorServer.DecoratorPatternExample.Services.Anniversaries
{
    public class AnniversaryService : ServiceBase<Anniversary, IAnniversayRepository>, IAnniversaryService
    {
        public AnniversaryService(IRepositoryBase<Anniversary> repo) : base(repo)
        {
        }
    }
}
