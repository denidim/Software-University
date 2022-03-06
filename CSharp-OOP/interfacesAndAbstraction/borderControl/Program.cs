using System;
using System.Collections.Generic;

namespace borderControl
{
    public interface IDetainable
    {
        bool CheckId(string endswith);
    }

    public class Citizen:IDetainable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public bool CheckId(string endswith) => Id.EndsWith(endswith);
    }

    public class Robot:IDetainable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

        public bool CheckId(string endswith) => Id.EndsWith(endswith);
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IDetainable> allPrisoners = new List<IDetainable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    allPrisoners.Add(citizen);
                }
                else if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0],tokens[1]);
                    allPrisoners.Add(robot);
                }
            }

            string lastDigitsOfFakeIds = Console.ReadLine();

            foreach (var prisoner in allPrisoners)
            {
                if(prisoner is Robot robot)
                {
                    if (robot.CheckId(lastDigitsOfFakeIds))
                    {
                        Console.WriteLine(robot.Id);
                    }
                }
                else if (prisoner is Citizen citizen)
                {
                    if (citizen.CheckId(lastDigitsOfFakeIds))
                    {
                        Console.WriteLine(citizen.Id);
                    }
                }
            }
        }
    }
}
