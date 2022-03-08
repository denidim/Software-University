using System;
using vechicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vehicle = commands[1];

                if (commands[0] == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    if (vehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else
                    {
                        truck.Drive(distance);
                    }
                }
                else
                {
                    double ammount = double.Parse(commands[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(ammount);
                    }
                    else
                    {
                        truck.Refuel(ammount);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
