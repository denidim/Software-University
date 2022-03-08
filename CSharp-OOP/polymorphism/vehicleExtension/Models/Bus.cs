namespace vehicleExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set
            {
                if (AirCon == false)
                {
                    base.FuelConsumption = value;
                }
                base.FuelConsumption = value + 1.4;
            }
        }

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
