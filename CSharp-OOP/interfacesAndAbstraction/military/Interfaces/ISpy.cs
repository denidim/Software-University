using System;
namespace military.Interfaces
{
    public interface ISpy: ISoldier
    {
        public int CodeNumber { get; set; }
    }
}
