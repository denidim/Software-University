using System;
namespace SoftUniDI.Attributes
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Constructor,AllowMultiple =true)]
    public class InjectAttribute : Attribute
    {
    }
}
