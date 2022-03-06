using System;
using Microsoft.Win32.SafeHandles;

namespace explicitInterfaces.Interfaces
{
    public interface IResident
    {
        // name, country and a method GetName()
        string name { get; }
        string country { get; }

        string GetName();
    }
}
