using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses//speedRacing
{
    public class Car
    {
        public string Model{ get; set; }
        public double FuelAmound { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public List<Car> CarList { get; set; }

        public Car()
        {
            CarList = new List<Car>();
        }
        public Car(string model,double fuelAmount,double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmound = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            TravelledDistance = 0;
        }

        public void Drive(double distance)
        {
            double consumption = distance * FuelConsumptionPerKilometer;
            if (FuelAmound - consumption >= 0)
            {
                FuelAmound -= consumption;
                TravelledDistance += distance;
                
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmound:f2} {TravelledDistance}";

        }
    }
    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car carList = new Car();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                carList.CarList.Add(new Car(input[0], double.Parse(input[1]), double.Parse(input[2])));
            }
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                string[] tockens = command.Split(' ');
                string carModel = tockens[1];
                double amountOfKm = int.Parse(tockens[2]);


                //carList.CarList.Where(c => c.Model == carModel).ToList().ForEach(c=>c.Drive(amountOfKm));

                foreach (var car in carList.CarList.Where(c => c.Model == carModel))
                {
                    car.Drive(amountOfKm);

                }

            }
            foreach (var car in carList.CarList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
