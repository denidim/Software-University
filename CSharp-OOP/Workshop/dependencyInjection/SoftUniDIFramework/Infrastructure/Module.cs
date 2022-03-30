namespace SoftUniDIFramework.Infrastructure
{
    using Contracts;
    using Services;
    using SoftUniDI.Modules;

    public class Module : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, FileWriter>();
        }
    }
}
