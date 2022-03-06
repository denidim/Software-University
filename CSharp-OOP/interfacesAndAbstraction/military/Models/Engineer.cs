using System.Collections.Generic;
using System.Text;
using military.Enumerations;
using military.Interfaces;

namespace military.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id,
            string firstName,
            string lastName,
            decimal salary,
            SoldierCorpEnum corp)
            : base(id, firstName, lastName, salary, corp)
        {
            Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");

            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}