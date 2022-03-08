using System;
using System.Collections.Generic;
using System.Linq;
using raiding.Models;

namespace raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while(true) 
            {
                if (heroes.Count == n)
                {
                    break;
                }
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                    Warrior warrior = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int boss = int.Parse(Console.ReadLine());

            if (heroes.Sum(x=>x.Power) >= boss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}