using BlazorServer.DecoratorPatternExample.Domain.Models;
using BlazorServer.DecoratorPatternExample.Services;
using BlazorServer.DecoratorPatternExample.Services.EventLoggers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorServer.DecoratorPatternExample.Decorators
{
    public abstract class LoggingServiceDecoratorBase<T, TService> : ILoggingServiceDecoratorBase<T>
        where T : ModelBase
        where TService : IServiceBase<T>
    {
        protected IServiceBase<T> Service;
        protected IEventLoggerService Logger;
        protected EventLogger Log;

        public LoggingServiceDecoratorBase(IServiceBase<T> service, IEventLoggerService logger)
        {
            Service = service;
            Logger = logger;
            Log = new EventLogger();
        }

        public virtual T Add(T entity)
        {
            CreateLog(JsonConvert.SerializeObject(entity));
            return Service.Add(entity);
        }

        public virtual bool Delete(T entity)
        {
            CreateLog(JsonConvert.SerializeObject(entity));
            return Service.Delete(entity);
        }

        public virtual bool DeleteById(int entityId)
        {
            CreateLog($"{entityId}");
            return Service.DeleteById(entityId);
        }

        public virtual IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            CreateLog("");
            return Service.Filter(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            CreateLog("");
            return Service.GetAll();
        }

        public virtual T? GetById(int id)
        {
            CreateLog($"{id}");
            return Service.GetById(id);
        }

        public virtual T Update(T entity)
        {
            CreateLog(JsonConvert.SerializeObject(entity));
            return Service.Update(entity);
        }

        private void CreateLog(string data)
        {
            StackTrace stackTrace = new StackTrace();
            string CallersName = stackTrace.GetFrame(1)!.GetMethod()!.Name;
            string ClassName = Service.GetType().Name;

            Log = new EventLogger
            {
                ActionDateTime = DateTime.Now,
                Service = ClassName,
                Action = CallersName,
                Description = $"{ClassName}.{CallersName}",
                Name = $"{ClassName}.{CallersName}",
                RequestData = data
            };

            Logger.Add(Log);

            Log = new EventLogger();
        }
    }
}
