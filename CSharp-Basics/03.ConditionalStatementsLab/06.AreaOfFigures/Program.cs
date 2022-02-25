using System;

namespace areaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();
            if (figure == "square")
            {
                var a = double.Parse(Console.ReadLine());
                var area = a * a;
                Console.WriteLine($"{area:F3}");
            }
            if (figure == "rectangle")
            {
                var l = double.Parse(Console.ReadLine());
                var w = double.Parse(Console.ReadLine());
                var area = l * w;
                Console.WriteLine($"{area:F3}");
            }
            if (figure == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                var area = Math.PI * r * r;
                Console.WriteLine($"{area:F3}");
            }
            if (figure == "triangle")
            {
                var a = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                var area = a * h / 2.0;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}

