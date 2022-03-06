using System;
using System.Collections.Generic;
using System.Linq;

namespace foodShortage

{
    public interface Ibuyer
    {
        int  Food { get; }

        void BuyFood();
    }

    public class Rebel:Ibuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

        private int food = 0;

        public int Food => food;

        public void BuyFood()
        {
            food += 5;
        }
    }

    public class Citizen : Ibuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
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

        private int food = 0;

        public int Food => food;

        public void BuyFood()
        {
            food += 10;
        }

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

    public class Pet
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Ibuyer> buyers = new List<Ibuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] strArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                Ibuyer ibuyer;


                if (strArr.Length == 4)
                {
                    ibuyer = new Citizen(strArr[0], int.Parse(strArr[1]), strArr[2], strArr[3]);
                }
                else
                {
                    ibuyer = new Rebel(strArr[0], int.Parse(strArr[1]), strArr[2]);
                }

                buyers.Add(ibuyer);

            }
            int total = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer is Rebel rebel && rebel.Name==command)
                    {
                        rebel.BuyFood();
                        total += rebel.Food;
                    }
                    else if (buyer is Citizen citizen && citizen.Name==command)
                    {
                        citizen.BuyFood();
                        total += citizen.Food;
                    }
                }
            }
            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
