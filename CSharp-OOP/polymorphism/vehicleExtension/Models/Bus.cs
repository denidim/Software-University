namespace vehicleExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        
         public override double FuelConsumption =>
            AirCon == false
            ? base.FuelConsumption
            : base.FuelConsumption + 1.4;

        
        public override void Drive(double distanceKm)
        {
            base.Drive(distanceKm);
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
    }
}
