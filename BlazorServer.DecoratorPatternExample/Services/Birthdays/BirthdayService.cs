using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories;
using BlazorServer.DecoratorPatternExample.Repositories.Birthdays;

namespace BlazorServer.DecoratorPatternExample.Services.Birthdays
{
    public class BirthdayService : ServiceBase<Birthday, IBirthdayRepository>, IBirthdayService
    {
        public BirthdayService(IRepositoryBase<Birthday> repo) : base(repo)
        {
        }
    }
}
