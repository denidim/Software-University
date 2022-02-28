namespace NeedForSpeed//needForSpeed
{

    public class Vehicle
    {

        private const double DefaultFuelConsumption = 12.5;

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption => DefaultFuelConsumption;

        public Vehicle(int horesePower,double fuel)
        {
            this.HorsePower = horesePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= FuelConsumption * kilometers;
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }
    }

    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }

    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }
    }

    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public Car(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }

    public class FamilyCar : Car
    {
        public FamilyCar(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }
    }

    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;

        public SportCar(int horesePower, double fuel) : base(horesePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }


    public class StartUp//Program
    {
        static void Main(string[] args)
        {

        }
    }
}
