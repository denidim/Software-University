using System;

namespace _02.RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rad = double.Parse(Console.ReadLine());
            var deg = rad * 180/Math.PI;
            Console.WriteLine(Math.Round(deg));
        }
    }
}
