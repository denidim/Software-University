using System;
using military.Enumerations;
using military.Interfaces;

namespace military.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,SoldierCorpEnum corp) : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public SoldierCorpEnum Corp { get; set; }
    }
}
