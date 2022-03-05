using System;

namespace classBoxData
{

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get => length;
            private set
            {
                ThrowIfInvalidAndSetNameOfProperty(value,nameof(Length));

                length = value;
            }
        }
        

        public double Width
        {
            get => width;
            private set
            {
                ThrowIfInvalidAndSetNameOfProperty(value, nameof(Width));

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                ThrowIfInvalidAndSetNameOfProperty(value, nameof(Height));

                height = value;
            }
        }

        private static void ThrowIfInvalidAndSetNameOfProperty(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }


        public Box(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            Height = heigth;
        }

        public double SurfaceArea()
        {
            return (2 * length * width) + (2 * length * height) + (2 * height * width);
        }

        public double LateralSurfaceArea()
        {
            return (2 * length * height)+ (2*width * height);
                //2 * height * (length + width);
        }

        public double Volume()
        {
            return height * width * length;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}\nLateral Surface Area - {this.LateralSurfaceArea():f2}\nVolume - {this.Volume():f2}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(new Box(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
