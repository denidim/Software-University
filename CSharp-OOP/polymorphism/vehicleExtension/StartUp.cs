using System;
using vehicleExtension.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] carInput = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckInput = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] busInput = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

            Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

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
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    else
                    {
                        bus.AirCon = true;
                        bus.Drive(distance);
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    double distance = double.Parse(commands[2]);
                    bus.AirCon = false;
                    bus.Drive(distance);
                }
                else
                {
                    double ammount = double.Parse(commands[2]);

                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(ammount);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(ammount);
                        }
                        else
                        {
                            bus.Refuel(ammount);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
