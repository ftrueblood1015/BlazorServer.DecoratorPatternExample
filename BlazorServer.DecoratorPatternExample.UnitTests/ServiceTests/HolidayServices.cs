using BlazorServer.DecoratorPatternExample.Decorators;
using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Repositories.EventLoggers;
using BlazorServer.DecoratorPatternExample.Repositories.Holidays;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;
using BlazorServer.DecoratorPatternExample.Services.Holidays;
using Shouldly;

namespace BlazorServer.DecoratorPatternExample.UnitTests.ServiceTests
{
    public class HolidayServices
    {
        private readonly HolidayService HolidayService;
        private readonly HolidayLoggingService HolidayLoggingService;
        private readonly EventLoggerService EventLoggerService;

        public HolidayServices() 
        {
            var HolidayRepo = MockBases.MockRepoBase.MockRepo<IHolidayRepository, Holiday>(new List<Holiday>()
                {
                    new Holiday() { Id = 1, Comments = "None", Date = DateTime.Now, Description = "Desc", IsActive = true, Name = "Holiday"},
                }
            );

            var LoggingRepo = MockBases.MockRepoBase.MockRepo<IEventLoggerRepository, EventLogger>(new List<EventLogger>()
                {
                    new EventLogger() { Id = 1, Name = "Name", Action = "GetAll", ActionDateTime = DateTime.Now, Comments = "Comments",
                        Description = "Desc", RequestData = "", Service = "BirthdayService"}
                }
            );

            HolidayService = new HolidayService(HolidayRepo.Object);
            EventLoggerService = new EventLoggerService(LoggingRepo.Object);
            HolidayLoggingService = new HolidayLoggingService(HolidayService, EventLoggerService);
        }

        [Test]
        public void No_Logging_In_Regular_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Holiday = new Holiday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            HolidayService.Add(Holiday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBe(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Add()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Holiday = new Holiday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            HolidayLoggingService.Add(Holiday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetAll()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            HolidayLoggingService.GetAll();

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_GetById()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Holiday = HolidayLoggingService.GetById(1);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Update()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Holiday = HolidayLoggingService.GetById(1);
            Holiday!.Date = DateTime.Now;
            Holiday = HolidayLoggingService.Update(Holiday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Works_For_Logging_Service_Delete()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var NewHoliday = new Holiday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            var Holiday = HolidayLoggingService.Add(NewHoliday);
            HolidayLoggingService.Delete(Holiday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldBeGreaterThan(LogCountPrevious);
        }

        [Test]
        public void Logging_Does_Not_Log_In_Logging_Service()
        {
            var LogsPrevious = EventLoggerService.GetAll();
            var LogCountPrevious = LogsPrevious.Count();

            var Holiday = new Holiday() { IsActive = true, Comments = "Comment", Date = DateTime.Now, Description = "Desc", Name = "Name"};
            HolidayLoggingService.Add(Holiday);

            var LogsAfter = EventLoggerService.GetAll();
            var LogCountAfter = LogsAfter.Count();

            LogCountAfter.ShouldNotBe(LogCountPrevious);
        }
    }
}
