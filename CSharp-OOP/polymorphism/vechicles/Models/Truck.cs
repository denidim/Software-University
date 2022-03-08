using System;
namespace vechicles.Models
{
    public class Truck : Vehicle
    {

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 1.6; }

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distanceKm)
        {
            base.Drive(distanceKm);
        }

        public override void Refuel(double ammount)
        {
            ammount -= ammount * 0.05;
            base.Refuel(ammount);
        }
    }
}
