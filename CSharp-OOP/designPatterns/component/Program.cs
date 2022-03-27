using System;

namespace component
{
    class Program
    {
        static void Main(string[] args)
        {
            GiftBase car = new SingleGift("BMW X5", 10m);
            GiftBase toy = new SingleGift("Pecka", 10m);

            CompositeGift bogBox = new CompositeGift("Root",0);

            bogBox.Add(car);
            bogBox.Add(toy);

            CompositeGift smallBox = new CompositeGift("Smallbox", 0);
            GiftBase dragon = new SingleGift("Dragon", 10m);

            smallBox.Add(dragon);

            bogBox.Add(smallBox);

            decimal finalPrice = bogBox.CalculateTotalPrice();

            Console.WriteLine(finalPrice);

        }
    }
}
