namespace SoftUniDIFramework
{
    using Core;
    using Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    using SoftUniDI;
    using SoftUniDIFramework.Services;

    class Program
    {
        static void Main(string[] args)
        {
            //without dependency injection
            //var consoleWriter = new ConsoleWriter();
            //var fileWriter = new FileWriter();
            //var reader = new ConsoleReader();
            //var engine = new Engine(consoleWriter,fileWriter,reader);

            //with microsoft dependency injection
            //var serviceProvider = DependencyResolver.GetServiceProvider();
            //var engine = serviceProvider.GetService<Engine>();//(typeof(Engine)) as Engine;

            ////with custom dependency injection
            var injector = DependancyInjector.CreateInjector(new Module());
            var engine = injector.Inject<Engine>();

            engine.Run();

        }
    }
}
