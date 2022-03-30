namespace SoftUniDIFramework.Infrastructure
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Contracts;
    using Core;
    using Services;

    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddTransient<IWriter, ConsoleWriter>()
                .AddTransient<IReader, ConsoleReader>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<Engine>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
