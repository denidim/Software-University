namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultCoffeeMilliliters = 50;
        private const decimal DefaultCoffeePrice = 3.50m;

        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine) : base(name, DefaultCoffeePrice, DefaultCoffeeMilliliters)
        {
            Caffeine = caffeine;
        }
    }
}
