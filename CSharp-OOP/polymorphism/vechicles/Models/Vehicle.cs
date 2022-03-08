using System;
namespace vechicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public virtual double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        public virtual void Drive(double distanceKm)
        {
            if (FuelQuantity >= distanceKm * FuelConsumption)
            {
                FuelQuantity -= distanceKm * FuelConsumption;

                Console.WriteLine($"{this.GetType().Name} travelled {distanceKm} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double ammount)
        {
            fuelQuantity += ammount;
        }
    }
}
