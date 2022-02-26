using System;

namespace Cars
{
    public interface IElectricCar
    {
        int Battery { get; }
    }

    public interface ICar
    {
        string Model { get; }
        string Color { get; }
        string Start();
        string Stop();
    }

    public abstract class Car : ICar
    {
        public string Model { get; private set;}

        public string Color { get; private set; }

        public Car(string model,string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }

    public class Tesla : Car, IElectricCar
    {
        public int Battery { get; private set; }

        public Tesla(string model, string color, int battery) : base(model, color)
        {
            Battery = battery;
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model} with {Battery}";
        }
    }

    public class Seat : Car
    {
        public Seat(string model, string color):base(model,color)
        {
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model}";
        }
    }


    public class StartUp
    {
        static void Main(string[] args)
        {
            Car seat = new Seat("Leon", "Grey");
            Console.WriteLine(seat.ToString());
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            Car tesla = new Tesla("Model 3", "Red", 2);
            Console.WriteLine(tesla.ToString());
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());

        }
    }
}
