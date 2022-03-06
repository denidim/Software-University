using System;
using System.Collections.Generic;

namespace bithdayCelebration
{
    public interface IBirthdate
    {
        string Birthdate { get; }

        bool CheckDate(string year);
    }

    public class Citizen : IBirthdate
    {
        public Citizen(string name, int age, string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }

        public bool CheckDate(string year) => Birthdate.EndsWith(year);
    }

    public class Robot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }

    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }

        public bool CheckDate(string year) => Birthdate.EndsWith(year);
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdate> dates = new List<IBirthdate>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0]=="Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3],tokens[4]);
                    dates.Add(citizen);
                }
                else if (tokens[0] == "Robot")
                {
                    Robot robot = new Robot(tokens[1], tokens[2]);
                }
                else if(tokens[0] == "Pet")
                {
                    Pet pet = new Pet(tokens[1],tokens[2]);
                    dates.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var date in dates)
            {
                if (date is Pet pet)
                {
                    if (date.CheckDate(year))
                    {
                        Console.WriteLine(pet.Birthdate);
                    }
                }
                else if (date is Citizen citizen)
                {
                    if (citizen.CheckDate(year))
                    {
                        Console.WriteLine(citizen.Birthdate);
                    }
                }
            }
        }
    }
}
