using System;

namespace vehicleExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private bool airCon;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public  double TankCapacity
        {
            get => tankCapacity;
            set => tankCapacity = value;
        }

        public bool AirCon
        {
            get => airCon;
            set => airCon = value;
        }

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
        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
                //Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
                //Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                FuelQuantity += amount;
            }
        }
    }
}
