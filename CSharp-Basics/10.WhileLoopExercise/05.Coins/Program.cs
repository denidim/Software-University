using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amount = decimal.Parse(Console.ReadLine());
            int coin = 0;

            coin += Convert.ToInt32(Math.Truncate(amount / 2));
            amount = amount % 2;
            coin += Convert.ToInt32(Math.Truncate(amount / 1));
            amount = amount % 1;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.50m));
            amount = amount % 0.5m;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.20m));
            amount = amount % 0.20m;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.10m));
            amount = amount % 0.10m;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.05m));
            amount = amount % 0.05m;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.02m));
            amount = amount % 0.02m;
            coin += Convert.ToInt32(Math.Truncate(amount / 0.01m));
            amount = amount % 0.01m;
            Console.WriteLine(coin);
        }
    }
}

