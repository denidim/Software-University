using System;
namespace military.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWork { get; }
    }
}
