using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using military.Enumerations;
using military.Interfaces;

namespace military.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(
            int id,
            string firstName,
            string lastName,
            decimal salary,
            SoldierCorpEnum corp)
            : base(id, firstName, lastName, salary, corp)
        {
            Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public void CompleteMision(string codeName)
        {
            if (Missions.Any(x => x.CodeName == codeName))
            {
                var mission = Missions.FirstOrDefault(x => x.CodeName == codeName);
                mission.MissionState = MissionStateEnum.Finished;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");

            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine($"Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item}");

            }
            return sb.ToString().TrimEnd();
        }
    }
}
