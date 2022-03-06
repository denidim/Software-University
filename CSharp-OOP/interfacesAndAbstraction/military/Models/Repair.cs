using System;
using military.Interfaces;

namespace military.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWork)
        {
            PartName = partName;
            HoursWork = hoursWork;
        }

        public string PartName { get; }

        public int HoursWork { get; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWork}";
        }
    }
}
