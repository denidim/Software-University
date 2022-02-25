using System;
using System.Text;

namespace carExtension//CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public string WhoAmI()
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {FuelQuantity}";
        }

        public void Drive(double distance)
        {
            double consumption = distance* (FuelConsumption  / 100);
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
            Car car1 = new Car();
            car1.Make = "VW";
            car1.Model = "MK3";
            car1.Year = 1992;
            car1.FuelQuantity = 200;
            car1.FuelConsumption = 200;
            car1.Drive(100);
            Console.WriteLine(car1.WhoAmI());
        }
    }
}
