using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            var recordInSec = double.Parse(Console.ReadLine());
            var distanceInMeters = int.Parse(Console.ReadLine());
            var secForMeter = double.Parse(Console.ReadLine());
            var resistance = Math.Floor((distanceInMeters / 15) * 12.5);
            var result = distanceInMeters * secForMeter + resistance;
            if (recordInSec > result)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {result:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {Math .Abs(recordInSec-result):f2} seconds slower.");
            }
        }
    }
}
