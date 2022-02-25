using System;

namespace _01.UsdToBgn
{
    class Program
    {
        static void Main(string[] args)
        {
            var usd = double.Parse(Console.ReadLine());
            var bgn = usd*1.79549;
            Console.WriteLine(bgn);
        }
    }
}
