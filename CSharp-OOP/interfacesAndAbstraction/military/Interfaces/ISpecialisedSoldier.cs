using System;
using military.Enumerations;

namespace military.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public SoldierCorpEnum Corp { get; set; }
    }
}
