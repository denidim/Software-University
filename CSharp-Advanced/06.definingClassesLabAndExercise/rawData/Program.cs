using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses//rawData
{
    public class Tire
    {
        public int Age { get; set; }
        public decimal Pressure { get; set; }

        public Tire(decimal pressure, int age)
        {
            Age = age;
            Pressure = pressure;
        }
    }

    public class Cargo
    {
        public string Type { get; set; }
        public int Weight { get; set; }

        public Cargo(int weight,string type)
        {
            Type = type;
            Weight = weight;
        }
    }

    public class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed,int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));

                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);

                Tire[] tires = new Tire[4];

                int tyreIndex = 0;

                for (int j = 5; j < 13; j+=2)
                {
                    tires[tyreIndex] = new Tire(decimal.Parse(input[j]), int.Parse(input[j+1]));

                    tyreIndex++;
                }

                Car car = new Car(input[0], engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            Func<Car,bool> filter = c => true;

            if (command == "fragile")
            {
                filter = c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1);
            }
            else
            {
                filter = c => c.Cargo.Type == command && c.Engine.Power > 250;
            }

            foreach (var item in cars.Where(filter))
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
