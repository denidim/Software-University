namespace SoftUniDI
{
    using Contracts;
    using Injectors;

    public static class DependancyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();

            return new Injector(module);
        }
    }
}
