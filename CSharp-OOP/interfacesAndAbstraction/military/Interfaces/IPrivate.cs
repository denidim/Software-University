using System;
namespace military.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; set; }
    }
}
