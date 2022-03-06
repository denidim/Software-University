using System;
using System.Collections;
using System.Collections.Generic;

namespace military.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get; set; }
    }
}
