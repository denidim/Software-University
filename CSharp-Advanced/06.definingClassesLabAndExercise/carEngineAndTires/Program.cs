using System;

namespace carEngineAndTires//CarManufacturer
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
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public Car(string make, string model, int year) : this(make, model)
        {
            Year = year;
        }

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year,
           double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
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
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
            };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}
