using System;
namespace vechicles.Models
{
    public class Car : Vehicle
    {
        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 0.9; }

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distanceKm)
        {
            base.Drive(distanceKm);
        }

        public override void Refuel(double ammount)
        {
            base.Refuel(ammount);
        }
    }
}
