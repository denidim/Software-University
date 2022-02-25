using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses//carSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public List<Engine> Engines { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            if (Engine.Displacement != 0)
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                sb.AppendLine("    Displacement: n/a");
            }
            if (Engine.Efficiency!= null)
            {
                sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            }
            else
            {
                sb.AppendLine("    Efficiency: n/a");
            }
            if (Weight != 0)
            {
                sb.AppendLine($"  Weight: {Weight}");
            }
            else
            {
                sb.AppendLine("  Weight: n/a");
            }
            if (Color != null)
            {
                sb.AppendLine($"  Color: {Color}");
            }
            else
            {
                sb.AppendLine("  Color: n/a");
            }
            return sb.ToString().TrimEnd();
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                engines.Add(BuilEngine(input));
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string input = Console.ReadLine();
                cars.Add(BuildCar(engines,input));
            }

            Print(cars);
        }

        public static void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {//model engine wight color
                Console.WriteLine(car.ToString());
            }
        }

        public static Car BuildCar(List<Engine> engines, string input)
        {
            string[] prop = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Engine engine = engines.Find(m => m.Model == prop[1]);

            Car car = new Car(prop[0],engine);

            if (prop.Length == 3)
            {
                bool isDigit = int.TryParse(prop[2], out int n);
                if (isDigit)
                {
                    car.Weight = int.Parse(prop[2]);
                }// int Weight string Color 
                else
                {
                    car.Color = prop[2];
                }
            }
            else if (prop.Length == 4)
            {
                car.Weight = int.Parse(prop[2]);
                car.Color = prop[3];
            }
            return car;
        }

        public  static Engine BuilEngine(string input)
        {//"{model} {power} {displacement} {efficiency}"
            string[] prop = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new Engine(prop[0],int.Parse(prop[1]));
            if (prop.Length == 3)
            {
                bool isDigit = int.TryParse(prop[2], out int n);
                if (isDigit)
                {
                    engine.Displacement = int.Parse(prop[2]);
                }
                else
                {
                    engine.Efficiency = prop[2];
                }
            }
            else if (prop.Length == 4)
            {
                engine.Displacement = int.Parse(prop[2]);
                engine.Efficiency = prop[3];
            }
            return engine;
        }
    }
}