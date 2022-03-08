namespace vehicleExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption  + 1.6;

        public override void Refuel(double amount)
        {
            if (amount + FuelQuantity <= TankCapacity)
            {
                amount -= amount * 0.05;
            }
            base.Refuel(amount);
        }
    }
}
