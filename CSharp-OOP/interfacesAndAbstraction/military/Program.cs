using System;
using System.Collections.Generic;
using System.Linq;
using military.Enumerations;
using military.Interfaces;
using military.Models;

namespace military
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ISoldier> battalion = new List<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ',StringSplitOptions.RemoveEmptyEntries );

                string soldierType = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    battalion.Add(@private);
                }
                if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    ICollection<IPrivate> privates = new List<IPrivate>();

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int currId = int.Parse(tokens[i]);

                        Private @private = (Private)battalion.FirstOrDefault(x => x.Id == currId);

                        privates.Add(@private);
                    }

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    lieutenantGeneral.Privates = privates;

                    battalion.Add(lieutenantGeneral);
                }
                if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    //case of invalid corps, the entire line should be skipped

                    Enum.TryParse(tokens[5],false,out SoldierCorpEnum corpEnum);
                    if (corpEnum == default)
                    {
                        continue;
                    }

                    List<IRepair> repairs = new List<IRepair>();
                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string part = tokens[i];
                        int hours = int.Parse(tokens[i+1]);
                        Repair repair = new Repair(part, hours);
                        repairs.Add(repair);
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corpEnum);
                    engineer.Repairs = repairs;

                    battalion.Add(engineer);
                }
                if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    Enum.TryParse(tokens[5], false ,out SoldierCorpEnum corpEnum);
                    if (corpEnum == default)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corpEnum);

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        string name = tokens[i];
                        string state = tokens[i + 1];

                        Enum.TryParse(state,false, out MissionStateEnum stateEnum);
                        if (stateEnum == default)
                        {
                            continue;
                        }

                        Mission mission = new Mission(name, stateEnum);

                        string currState = mission.MissionState.ToString();

                        commando.Missions.Add(mission);
                    }

                    battalion.Add(commando);
                }
                if(soldierType== "Spy")
                {
                    ISpy spy = new Spy(id, firstName, lastName, int.Parse(tokens[4]));
                    battalion.Add(spy);
                }
            }

            foreach (var soldier in battalion)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
