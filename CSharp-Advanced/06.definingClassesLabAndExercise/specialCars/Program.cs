using System;
using System.Collections.Generic;
using System.Linq;

namespace specialCars//CarManufacturer
{
    public class Tire
    {
        public int Year { get; set; }
        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
    }

    public class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public List<Engine> Engines { get; set; }
        public Engine Engine { get; set; }
        public List<Tire[]> Tires { get; set; }
        public Tire[] Tire { get; set; }

        public Car(string make, string model, int year, double fuelQuantity,
             double fuelConsumption, Engine engine, Tire[] tires)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tire = tires;
        }

        public void Drive(double distance)
        {
            double consumption = distance * (FuelConsumption / 100);
            if (FuelQuantity - consumption >= 0)
            {
                FuelQuantity -= consumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nHorsePowers: {Engine.HorsePower}\nFuelQuantity: {FuelQuantity}";
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tiresList = new List<Tire[]>();

            string tiresInput;

            while ((tiresInput = Console.ReadLine()) != "No more tires")
            {
                double[] tockens = tiresInput.Split(' ').Select(double.Parse).ToArray();

                Tire[] newTires = new Tire[tockens.Length / 2];

                int tireCounter = 0;

                for (int i = 0; i < tockens.Length; i += 2)
                {
                    newTires[tireCounter] = new Tire((int)tockens[i], tockens[i + 1]);
                    tireCounter++;
                }

                tiresList.Add(newTires);

            }

            var engines = new List<Engine>();

            string engineInput;

            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                double[] tockens = engineInput.Split(' ').Select(double.Parse).ToArray();

                for (int i = 0; i < tockens.Length; i += 2)
                {
                    engines.Add(new Engine((int)tockens[i], tockens[i + 1]));
                }
            }

            var cars = new List<Car>();

            string carInput;

            while ((carInput = Console.ReadLine()) != "Show special")
            {
                string[] tockens = carInput.Split(' ');

                int engineIndex = int.Parse(tockens[5]);

                int tiresIndex = int.Parse(tockens[6]);

                var engine = new Engine(0, 0);
                engine = engines[engineIndex];

                var tires = new Tire[4];
                tires = tiresList[tiresIndex];

                cars.Add(new Car(tockens[0], tockens[1], int.Parse(tockens[2]), double.Parse(tockens[3]),
                    double.Parse(tockens[4]), engine, tires));

            }

            Func<Car, bool> filter = c => c.Year >= 2017 && c.Engine.HorsePower > 330;

            foreach (var car in cars.Where(filter))
            {

                if (IsSpecial(car))
                {
                    car.Drive(20);

                    Console.WriteLine(car.ToString());
                }
            }
        }

        public static bool IsSpecial(Car car)
        {
            double sum = 0;
            foreach (var item in car.Tire)
            {
                sum += item.Pressure;
            }
            if (sum > 9 && sum < 10)
            {
                return true;
            }
            return false;
        }
    }
}
