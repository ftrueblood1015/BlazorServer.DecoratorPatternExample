using BlazorServer.DecoratorPatternExample.Decorators;
using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories.Anniversaries;
using BlazorServer.DecoratorPatternExample.Repositories.EventLoggers;
using BlazorServer.DecoratorPatternExample.Services.Anniversaries;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;
using Shouldly;

namespace BlazorServer.DecoratorPatternExample.UnitTests.ServiceTests
{
    public class AnniversaryServices
    {
        private readonly AnniversaryService AnniversaryService;
        private readonly AnniversaryLoggingService AnniversaryLoggingService;
        private readonly EventLoggerService EventLoggerService;

        public AnniversaryServices()
        {
            var AnniversayRepo = MockBases.MockRepoBase.MockRepo<IAnniversayRepository, Anniversary>(new List<Anniversary>()
                {
                    new Anniversary() { Id = 1, Comments = "None", Date = DateTime.Now, Description = "Desc", IsActive = true, Name = "Anniversary"},
                }
            );

            var LoggingRepo = MockBases.MockRepoBase.MockRepo<IEventLoggerRepository, EventLogger>(new List<EventLogger>()
                {
                    new EventLogger() { Id = 1, Name = "Name", Action = "GetAll", ActionDateTime = DateTime.Now, Comments = "Comments",
                        Description = "Desc", RequestData = "", Service = "BirthdayService"}
                }
            );

            AnniversaryService = new AnniversaryService(AnniversayRepo.Object);
            EventLoggerService = new EventLoggerService(LoggingRepo.Object);
            AnniversaryLoggingService = new AnniversaryLoggingService(AnniversaryService, EventLoggerService);
        }

        [Test]
        public void No_Logging_In_Regular_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Anniversary = new Anniversary() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            AnniversaryService.Add(Anniversary);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBe(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Add()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Anniversary = new Anniversary() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            AnniversaryLoggingService.Add(Anniversary);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetAll()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            AnniversaryLoggingService.GetAll();

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetById()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = AnniversaryLoggingService.GetById(1);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Update()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = AnniversaryLoggingService.GetById(1);
            Birthday!.Date = DateTime.Now;
            Birthday = AnniversaryLoggingService.Update(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Delete()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var NewAnniversary = new Anniversary() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            var Birthday = AnniversaryLoggingService.Add(NewAnniversary);
            AnniversaryLoggingService.Delete(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Does_Not_Log_In_Logging_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Anniversary = new Anniversary() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            AnniversaryLoggingService.Add(Anniversary);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldNotBe(LogCountPrevious);
        }
    }
}
