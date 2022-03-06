using System;
using System.Collections;
using System.Collections.Generic;

namespace military.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; set; }
    }
}
