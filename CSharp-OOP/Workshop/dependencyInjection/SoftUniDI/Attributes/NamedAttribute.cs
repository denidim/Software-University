namespace SoftUniDI
{
    using System;

    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Parameter,AllowMultiple =true)]
    public class NamedAttribute : Attribute
    {
        public string Name {get;}

        public NamedAttribute(string name)
        {
            Name = name;
        }
    }
}
