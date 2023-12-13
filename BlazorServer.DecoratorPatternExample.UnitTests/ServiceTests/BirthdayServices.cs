using BlazorServer.DecoratorPatternExample.Decorators;
using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories.Birthdays;
using BlazorServer.DecoratorPatternExample.Repositories.EventLoggers;
using BlazorServer.DecoratorPatternExample.Services.Birthdays;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;
using Shouldly;

namespace BlazorServer.DecoratorPatternExample.UnitTests.ServiceTests
{
    public class BirthdayServices
    {
        private readonly BirthdayService BirthdayService;
        private readonly BirthdayLoggingService BirthdayLoggingService;
        private readonly EventLoggerService EventLoggerService;

        public BirthdayServices()
        {
            var BirthdayRepo = MockBases.MockRepoBase.MockRepo<IBirthdayRepository, Birthday>(new List<Birthday>()
                {
                    new Birthday() { Id = 1, Comments = "None", Date = DateTime.Now, Description = "Desc", IsActive = true, Name = "BDay"},
                }
            );

            var LoggingRepo = MockBases.MockRepoBase.MockRepo<IEventLoggerRepository, EventLogger>(new List<EventLogger>()
                {
                    new EventLogger() { Id = 1, Name = "Name", Action = "GetAll", ActionDateTime = DateTime.Now, Comments = "Comments", 
                        Description = "Desc", RequestData = "", Service = "BirthdayService"}
                }    
            );

            BirthdayService = new BirthdayService(BirthdayRepo.Object);
            EventLoggerService = new EventLoggerService(LoggingRepo.Object);
            BirthdayLoggingService = new BirthdayLoggingService(BirthdayService, EventLoggerService);
        }

        [Test]
        public void No_Logging_In_Regular_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = new Birthday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            BirthdayService.Add(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBe(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Add()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = new Birthday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            BirthdayLoggingService.Add(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetAll()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            BirthdayLoggingService.GetAll();

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetById()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = BirthdayLoggingService.GetById(1);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Update()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = BirthdayLoggingService.GetById(1);
            Birthday!.Date = DateTime.Now;
            Birthday = BirthdayLoggingService.Update(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Delete()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var NewBirthday = new Birthday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            var Birthday = BirthdayLoggingService.Add(NewBirthday);
            BirthdayLoggingService.Delete(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Does_Not_Log_In_Logging_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Birthday = new Birthday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            BirthdayLoggingService.Add(Birthday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldNotBe(LogCountPrevious);
        }
    }
}
