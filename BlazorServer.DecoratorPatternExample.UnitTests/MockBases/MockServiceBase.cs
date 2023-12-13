using BlazorServer.DecoratorPatternExample.Decorators;
using BlazorServer.DecoratorPatternExample.Domain.Models;
using Moq;

namespace BlazorServer.DecoratorPatternExample.UnitTests.MockBases
{
    public static class MockServiceBase
    {
        public static Mock<TService> MockLoggingService<TService, T>(IEnumerable<T> list)
            where TService : class, ILoggingServiceDecoratorBase<T>
            where T : ModelBase
        {
            var mock = new Mock<TService>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) => x);

            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns((int Id) => { return list.FirstOrDefault(y => y.Id == Id); });

            // getall
            mock.Setup(x => x.GetAll()).Returns(() => list);

            // update
            mock.Setup(x => x.Update(It.IsAny<T>())).Returns((T Entity) => Entity);

            // delete
            mock.Setup(x => x.Delete(It.IsAny<T>())).Returns((T Entity) => { return !list.Contains(Entity);  });

            return mock;
        }

        public static Mock<TService> MockService<TService, T>()
            where TService : class, ILoggingServiceDecoratorBase<T>
            where T : ModelBase
        {
            var mock = new Mock<TService>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) => x);

            mock.Setup(x => x.Update(It.IsAny<T>())).Returns((T Entity) => Entity);


            return mock;
        }
    }
}
