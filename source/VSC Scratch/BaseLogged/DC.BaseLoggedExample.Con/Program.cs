using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DC.BaseLoggedExample.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("Abstract base class defines function to get this self's type\nShould be ThisClassIs:\n");

            var thisClassIs = new ThisClassIs();

            Console.WriteLine(thisClassIs.WhatIsMyType.ToString());

            Console.WriteLine(new string('=', 80));
            Console.WriteLine();

            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug)
                .AddSingleton<IFooService, FooService>()
                .AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("And now for something Foo");

            Console.WriteLine(new string('=', 80));
            
            serviceProvider.GetService<IFooService>().DoSomeFoo(10);
            serviceProvider.GetService<IBarService>().GetSomeBar(1000);

            Console.WriteLine(new string('=', 80));

            // https://github.com/aspnet/Logging/issues/631
            // So this is because we do console logging on a background thread. 
            // So if the application exits too fast then the logger doesn't have time to log.
            // Disposing of the ServiceCollection will flush the log.

            serviceProvider.Dispose();
        }
    }

    internal  interface IFooService
    {
        void DoSomeFoo(int fooParam);
    }

    internal interface IBarService
    {
        int GetSomeBar(int barParam);
    }

    internal abstract class BaseLoggedClass<T>
    {
        protected readonly ILogger<T> _logger;
        public BaseLoggedClass(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public Type WhatIsMyType { get { return typeof(T); } }
    }

    internal class FooService : BaseLoggedClass<FooService>, IFooService
    {
        public FooService(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public void DoSomeFoo(int fooParam)
        {
            _logger.LogInformation($"We got some {fooParam} for foo");
        }
    }

    internal class BarService : BaseLoggedClass<BarService>, IBarService
    {
        public BarService(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

        }

        public int GetSomeBar(int barParam)
        {
            _logger.LogInformation($"Doing something with {barParam} Bar");
            return barParam * 2;
        }
    }



    internal abstract class BaseClass<T>
    {
        public Type WhatIsMyType => typeof(T);
    }

    internal class ThisClassIs : BaseClass<ThisClassIs> { }
}
